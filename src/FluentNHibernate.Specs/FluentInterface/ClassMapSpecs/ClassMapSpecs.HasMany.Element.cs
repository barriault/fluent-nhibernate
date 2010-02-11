using System.Linq;
using FluentNHibernate.MappingModel.Collections;
using FluentNHibernate.Specs.FluentInterface;
using FluentNHibernate.Specs.FluentInterface.Fixtures;
using Machine.Specifications;

namespace FluentNHibernate.Testing.FluentInterfaceTests.ClassMapSpecs
{
    public class when_class_map_is_told_to_map_a_has_many_bag_of_string_elements_with_a_custom_column : ProviderSpec
    {
        Because of = () =>
        {
            var mapping = map_as_class<EntityWithCollections>(m => m.HasMany(x => x.BagOfStrings, "custom"));
            collection = mapping.Collections.SingleOrDefault();
        };

        It should_use_the_specified_column_name_for_the_element = () =>
            collection.Element.Columns.Single().Name.ShouldEqual("custom");

        protected static ICollectionMapping collection;
    }

    public class when_class_map_is_told_to_map_a_has_many_bag_of_string_elements : ProviderSpec
    {
        Because of = () =>
        {
            var mapping = map_as_class<EntityWithCollections>(m => m.HasMany(x => x.BagOfStrings));
            collection = mapping.Collections.SingleOrDefault();
        };

        It should_create_the_element_mapping_with_the_correct_type = () =>
            collection.Element.Type.GetUnderlyingSystemType().ShouldEqual(typeof(string));

        It should_create_the_collection_as_a_bag = () =>
            collection.ShouldBeOfType<BagMapping>();

        Behaves_like<HasManyElementBehaviour> an_has_many_element;

        protected static ICollectionMapping collection;
    }

    public class when_class_map_is_told_to_map_a_has_many_bag_of_int_elements_with_a_custom_column : ProviderSpec
    {
        Because of = () =>
        {
            var mapping = map_as_class<EntityWithCollections>(m => m.HasMany(x => x.BagOfStrings, "custom"));
            collection = mapping.Collections.SingleOrDefault();
        };

        It should_use_the_specified_column_name_for_the_element = () =>
            collection.Element.Columns.Single().Name.ShouldEqual("custom");

        protected static ICollectionMapping collection;
    }

    public class when_class_map_is_told_to_map_a_has_many_bag_of_int_elements : ProviderSpec
    {
        Because of = () =>
        {
            var mapping = map_as_class<EntityWithCollections>(m => m.HasMany(x => x.BagOfStrings));
            collection = mapping.Collections.SingleOrDefault();
        };

        It should_create_the_element_mapping_with_the_correct_type = () =>
            collection.Element.Type.GetUnderlyingSystemType().ShouldEqual(typeof(string));

        It should_create_the_collection_as_a_bag = () =>
            collection.ShouldBeOfType<BagMapping>();

        It should_use_the_default_column_name_for_the_element = () =>
            collection.Element.Columns.Single().Name.ShouldEqual("value");

        Behaves_like<HasManyElementBehaviour> an_has_many_element;

        protected static ICollectionMapping collection;
    }
}