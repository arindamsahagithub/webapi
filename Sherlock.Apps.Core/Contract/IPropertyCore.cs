using Sherlock.Apps.Model;

namespace Sherlock.Apps.Core.Contract;

public interface IPropertyCore
{
    Task<bool> AddProperty(Property property);
}