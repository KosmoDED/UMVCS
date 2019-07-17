using UnityEngine;

namespace RMC.Attributes
{
	/// <summary>
	/// By default the <see cref="ObservablePropertyDrawer"/> only shows
	/// SOME of its properties in the inspector. If you want to show ALL,
	/// use this attribute before a <see cref="Observable"/> field.
	/// </summary>
	public class ObservableShowAllChildrenAttribute : PropertyAttribute
	{
	}
}