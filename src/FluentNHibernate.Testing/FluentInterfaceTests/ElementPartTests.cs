using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Testing.Utils;
using NUnit.Framework;
using FluentNHibernate.Mapping;
using FluentNHibernate.Testing.DomainModel.Mapping;
using FluentNHibernate.MappingModel.Collections;

namespace FluentNHibernate.Testing.FluentInterfaceTests
{
    [TestFixture]
    public class ElementPartTests
    {
        [Test]
        public void CanSetLength()
        {
            var part = new ElementPart(typeof(MappedObject), typeof(string));
            part.Length(50);

            ElementMapping elementMapping = part.GetElementMapping();
            elementMapping.Length.ShouldEqual(50);
        }

        [Test]
        public void CanSetFormula()
        {
            var part = new ElementPart(typeof(MappedObject), typeof(string));
            part.Formula("formula");

            ElementMapping elementMapping = part.GetElementMapping();
            elementMapping.Formula.ShouldEqual("formula");
        }
    }
}
