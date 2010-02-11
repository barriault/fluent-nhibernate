using FluentNHibernate.MappingModel.ClassBased;
using FluentNHibernate.Specs.FluentInterface.Fixtures;
using Machine.Specifications;

namespace FluentNHibernate.Specs.FluentInterface.SubclassMapSpecs
{
    public class when_subclass_map_is_told_to_map_a_property : ProviderSpec
    {
        Because of = () =>
            mapping = map_as_subclass<EntityWithProperties>(o => o.Map(x => x.Name));

        Behaves_like<ClasslikePropertyBehaviour> a_property_in_a_classlike_mapping;
        
        protected static SubclassMapping mapping;
    }
}