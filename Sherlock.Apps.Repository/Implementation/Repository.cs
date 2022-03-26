using Sherlock.Apps.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Sherlock.Apps.Model;
using Gremlin.Net.Driver;

namespace Sherlock.Apps.Repository.Implementation
{
    public abstract class Repository<T,K> : IRepository<T,K>
    where T : class 
    where K : Enum
    {
        protected GremlinClient _gremlinClient;
        protected Type _valueType;
        protected IList<PropertyInfo> _props;
        protected Repository(GremlinClient gremlinClient)
        {
            _gremlinClient = gremlinClient;
        }
        private void SetValueTypeAndProperty(T value)
        {
            if(value==null) throw new ArgumentNullException();
            _valueType = value.GetType();
            _props = new List<PropertyInfo>(_valueType.GetProperties());
        }     
        public async Task<CDM> AddNodeAsync(T value)
        {
            CDM cdm = null;
            SetValueTypeAndProperty(value);

            var idProp = _props.FirstOrDefault(p => p.Name == "id");
            var pkProp = _props.FirstOrDefault(p => p.Name == "pk");

            if(idProp == null || pkProp == null) throw new ArgumentException("Entity id/pk is/are not present");
            
            var addNodeQuery = $"g.addV('{_valueType.Name}')";
            foreach (var prop in _props)
            {
                object propValue = prop.GetValue(value, null);
                if (propValue != null)
                {
                    addNodeQuery += ".property('" + prop.Name + "', '" + propValue + "')";
                }
            }

            if (addNodeQuery.Contains("property"))
            {
                var result = await _gremlinClient.SubmitWithSingleResultAsync<object>(addNodeQuery);
                var serialized = Newtonsoft.Json.JsonConvert.SerializeObject(result);
                cdm = Newtonsoft.Json.JsonConvert.DeserializeObject<CDM>(serialized);
            }   

            return cdm;
        }
        public async Task<CDM> UpdateNodeAsync(T value) {
            CDM cdm = null;
            SetValueTypeAndProperty(value);
            
            var idProp = _props.FirstOrDefault(p => p.Name == "id");
            if(idProp == null) throw new ArgumentException("Entity id is not present");            

            var updateNodeQuery = $"g.V('{idProp.GetValue(value)}')";
            _props.Remove(idProp);
            var pkProp = _props.FirstOrDefault(p => p.Name == "pk");
            if(pkProp != null)
            {
                _props.Remove(pkProp);
            }
            
            foreach (var prop in _props)
            {
                object propValue = prop.GetValue(value, null);
                if (propValue != null)
                {
                    updateNodeQuery += ".property('" + prop.Name + "', '" + propValue + "')";
                }
            }

            if (updateNodeQuery.Contains("property"))
            {
                var result = await _gremlinClient.SubmitWithSingleResultAsync<object>(updateNodeQuery);
                var serialized = Newtonsoft.Json.JsonConvert.SerializeObject(result);
                cdm = Newtonsoft.Json.JsonConvert.DeserializeObject<CDM>(serialized);
            }  

            return cdm;           
        }
        public async Task<CDM> AddEdgeAsync(string outNodeId, string inNodeId,K edgeName)
        {
            CDM cdm = null;            
            if(string.IsNullOrEmpty(outNodeId) || string.IsNullOrEmpty(inNodeId) || string.IsNullOrEmpty(edgeName.ToString()))
                throw new ArgumentNullException("Input parameter/s is/are null");
            
            var addEdgeQuery = $"g.V('{outNodeId}').addE('{edgeName.ToString()}').to(g.V('{inNodeId}'))";
            
            var result = await _gremlinClient.SubmitWithSingleResultAsync<object>(addEdgeQuery);
            var serialized = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            cdm = Newtonsoft.Json.JsonConvert.DeserializeObject<CDM>(serialized);            

            return cdm;
        }
        public async Task<IEnumerable<CDM>> GetAllAsync(Vertices type)
        {            
            IEnumerable<CDM> cdmList = null;
            var getAllQuery = $"g.V().hasLabel('{type.ToString()}')";            
            var result = await _gremlinClient.SubmitAsync<object>(getAllQuery);
            var serialized = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            cdmList = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<CDM>>(serialized);
            
            return cdmList;
        }
        public async Task<CDM> GetByIdAsync(string id)
        {
            if(string.IsNullOrEmpty(id))
                throw new ArgumentNullException("Input parameter is null");
            
            CDM cdm = null;
            var getByIdQuery = $"g.V('{id}')";            
            var result = await _gremlinClient.SubmitWithSingleResultAsync<object>(getByIdQuery);
            var serialized = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            cdm = Newtonsoft.Json.JsonConvert.DeserializeObject<CDM>(serialized);

            return cdm;
        }
    }
}
