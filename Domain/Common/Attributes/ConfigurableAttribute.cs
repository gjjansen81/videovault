using System;

namespace VideoVault.Domain.Common.Attributes;

[AttributeUsage(AttributeTargets.All)]
public class ConfigurableAttribute : Attribute
{
    public static readonly ConfigurableAttribute Default = new ConfigurableAttribute();

    public override bool IsDefaultAttribute() => Equals(Default);
}