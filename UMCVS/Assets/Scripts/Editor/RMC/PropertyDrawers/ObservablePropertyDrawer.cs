using RMC.Attributes;
using RMC.Data.Types;
using UnityEditor;
using UnityEngine;

namespace RMC.PropertyDrawers
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	[CustomPropertyDrawer(typeof(Observable), true)]
	public class ObservablePropertyDrawer : PropertyDrawer
	{
		private const float GapVertical = 5;
		private bool _isShowingUnityEvent = true;

		public override void OnGUI(Rect position,
								   SerializedProperty property,
								   GUIContent label)
		{
			object[] attributes = fieldInfo.GetCustomAttributes(true);

			ObservableShowAllChildrenAttribute showAllAttribute = 
				attributes[0] as ObservableShowAllChildrenAttribute;

			_isShowingUnityEvent = showAllAttribute != null;

			SerializedProperty valueSP = property.FindPropertyRelative("_value");
			EditorGUI.PropertyField(position, valueSP, label, true);
			
			if (_isShowingUnityEvent)
			{
				SerializedProperty onChangedSP = property.FindPropertyRelative("OnChanged");
				position.y += EditorGUIUtility.singleLineHeight + GapVertical;
				position.x += EditorGUIUtility.labelWidth;
				position.width -= EditorGUIUtility.labelWidth;
				EditorGUI.PropertyField(position, onChangedSP, new GUIContent("OnChanged"), true);
			}
			
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			if (_isShowingUnityEvent)
			{
				return EditorGUIUtility.singleLineHeight * 6 + GapVertical * 2;
			}
			else
			{
				return EditorGUIUtility.singleLineHeight;
			}
		}

	}
}
