using System.Collections.Generic;
using FluentNHibernate.Testing.Utils;
using NUnit.Framework;

namespace FluentNHibernate.Testing.FluentInterfaceTests
{
    [TestFixture]
    public class OneToManyMethodAccessTests : BaseModelFixture
    {
        [Test]
        public void ShouldGuessBackingFieldName()
        {
            OneToMany(x => x.GetOtherChildren())
                .Mapping(m => {})
                .ModelShouldMatch(x => x.Name.ShouldEqual("otherChildren"));
        }
    }
}