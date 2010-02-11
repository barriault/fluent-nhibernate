using System;
using System.Collections.Generic;
using System.Linq;
using FluentNHibernate.MappingModel;
using FluentNHibernate.MappingModel.Collections;
using FluentNHibernate.Utils;

namespace FluentNHibernate.Mapping
{
    public class ElementPart
    {
        private readonly Type containingEntityType;
        private readonly AttributeStore<ElementMapping> attributes = new AttributeStore<ElementMapping>();
        private readonly ColumnMappingCollection<ElementPart> columns;

        public ElementPart(Type containingEntityType, Type elementType)
        {
            this.containingEntityType = containingEntityType;
            columns = new ColumnMappingCollection<ElementPart>(this);

            attributes.SetDefault(x => x.Type, new TypeReference(elementType));
        }

        public ElementPart Column(string elementColumnName)
        {
            columns.Add(elementColumnName);
            return this;
        }

        public ColumnMappingCollection<ElementPart> Columns
        {
            get { return columns; }
        }

        public ElementPart Type<TElement>()
        {
            attributes.Set(x => x.Type, new TypeReference(typeof(TElement)));
            return this;
        }

        public ElementMapping GetElementMapping()
        {
            var mapping = new ElementMapping(attributes.CloneInner());
            mapping.ContainingEntityType = containingEntityType;

            if (Columns.Any())
            {
                foreach (var column in Columns)
                    mapping.AddColumn(column);
            }
            else
                mapping.AddDefaultColumn(new ColumnMapping { Name = "value" });
            
            return mapping;
        }

        public ElementPart Length(int length)
        {
            attributes.Set(x => x.Length, length);
            return this;
        }

        public ElementPart Formula(string formula)
        {
            attributes.Set(x => x.Formula, formula);
            return this;
        }
    }
}