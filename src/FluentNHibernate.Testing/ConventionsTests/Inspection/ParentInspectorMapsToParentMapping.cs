using System;
using System.Linq.Expressions;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.MappingModel;
using FluentNHibernate.Utils.Reflection;
using FluentNHibernate.Testing.Utils;
using NUnit.Framework;

namespace FluentNHibernate.Testing.ConventionsTests.Inspection
{
    [TestFixture, Category("Inspection DSL")]
    public class ParentInspectorMapsToParentMapping
    {
        private ParentMapping mapping;
        private IParentInspector inspector;

        [SetUp]
        public void CreateDsl()
        {
            mapping = new ParentMapping();
            inspector = new ParentInspector(mapping);
        }

        [Test]
        public void NameMapped()
        {
            mapping.Name = "name";
            inspector.Name.ShouldEqual("name");
        }

        [Test]
        public void NameIsSet()
        {
            mapping.Name = "name";
            inspector.IsSet(Prop(x => x.Name))
                .ShouldBeTrue();
        }

        [Test]
        public void NameIsNotSet()
        {
            inspector.IsSet(Prop(x => x.Name))
                .ShouldBeFalse();
        }

        #region Helpers

        private Member Prop(Expression<Func<IAnyInspector, object>> propertyExpression)
        {
            return ReflectionHelper.GetMember(propertyExpression);
        }

        #endregion
    }
}