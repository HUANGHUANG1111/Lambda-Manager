using Microsoft.CodeAnalysis;

namespace System.Runtime.CompilerServices;

[CompilerGenerated]
[Microsoft.CodeAnalysis.Embedded]
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter, AllowMultiple = false, Inherited = false)]
internal sealed class NativeIntegerAttribute : Attribute
{
	public readonly bool[] TransformFlags;

	public NativeIntegerAttribute()
	{
		TransformFlags = new bool[1] { true };
	}

	public NativeIntegerAttribute(bool[] P_0)
	{
		TransformFlags = P_0;
	}
}