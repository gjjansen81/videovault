using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoVault.Application.Common.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class PlaceholderAttribute : Attribute
    {
        public static readonly PlaceholderAttribute Default = new PlaceholderAttribute();

        public PlaceholderAttribute() : this(string.Empty)
        {
        }

        public PlaceholderAttribute(string placeholder)
        {
            PlaceholderValue = placeholder;
        }

        public virtual string Placeholder => PlaceholderValue;

        protected string PlaceholderValue { get; set; }

        public override bool Equals([NotNullWhen(true)] object? obj) =>
            obj is PlaceholderAttribute other && other.Placeholder == Placeholder;

        public override int GetHashCode() => Placeholder?.GetHashCode() ?? 0;

        public override bool IsDefaultAttribute() => Equals(Default);
    }
}
