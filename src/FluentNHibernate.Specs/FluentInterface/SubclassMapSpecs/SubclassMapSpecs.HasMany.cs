using FluentNHibernate.MappingModel.ClassBased;
using FluentNHibernate.Specs.FluentInterface.Fixtures;
using Machine.Specifications;

namespace FluentNHibernate.Specs.FluentInterface.SubclassMapSpecs
{
    public class when_subclass_map_is_told_to_map_a_has_many_bag : ProviderSpec
    {
        Because of = () =>
            mapping = map_as_subclass<EntityWithCollections>(m => m.HasMany(x => x.BagOfChildren));

        Behaves_like<ClasslikeBagBehaviour> a_bag_in_a_classlike_mapping;

        protected static SubclassMapping mapping;
    }

    public class when_subclass_map_is_told_to_map_a_has_many_set : ProviderSpec
    {
        Because of = () =>
            mapping = map_as_subclass<EntityWithCollections>(m => m.HasMany(x => x.SetOfChildren));

        Behaves_like<ClasslikeSetBehaviour> a_set_in_a_classlike_mapping;

        protected static SubclassMapping mapping;
    }

    public class when_subclass_map_is_told_to_map_a_has_many_list_with_default_index : ProviderSpec
    {
        Because of = () =>
            mapping = map_as_subclass<EntityWithCollections>(m => m.HasMany(x => x.BagOfChildren).AsList());

        Behaves_like<ClasslikeListWithDefaultIndexBehaviour> a_list_with_the_default_index_in_a_classlike_mapping;

        protected static SubclassMapping mapping;
    }

    public class when_subclass_map_is_told_to_map_a_has_many_list_with_custom_index : ProviderSpec
    {
        Because of = () =>
            mapping = map_as_subclass<EntityWithCollections>(m => m.HasMany(x => x.BagOfChildren).AsList(x =>
            {
                x.Column("custom-column");
                x.Type<IndexTarget>();
            }));

        Behaves_like<ClasslikeListWithCustomIndexBehaviour> a_list_with_a_custom_index_in_a_classlike_mapping;

        protected static SubclassMapping mapping;
    }
}