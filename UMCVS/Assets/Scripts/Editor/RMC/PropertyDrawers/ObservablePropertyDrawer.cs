using RMC.Attributes;
using RMC.Data.Types;
using System;
using System.Reflection;
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

			if (valueSP != null)
			{
				EditorGUI.BeginChangeCheck();
				EditorGUI.PropertyField(position, valueSP, label, true);
				if (EditorGUI.EndChangeCheck())
				{
					// Use reflection to prompt the class
					// to invoke its OnChange. This method is protected
					// because it otherwise should not be called externally.
					Observable observable = fieldInfo.GetValue(property.serializedObject.targetObject) as Observable;
					Type thisType = observable.GetType();

					MethodInfo OnValidate = thisType.GetMethod("InvokeOnValidate", BindingFlags.NonPublic | BindingFlags.Instance);
					OnValidate.Invoke(observable, null);

					MethodInfo invokeOnChanged = thisType.GetMethod("InvokeOnChanged", BindingFlags.NonPublic | BindingFlags.Instance);
					invokeOnChanged.Invoke(observable, null);
				}
			}

			if (_isShowingUnityEvent)
			{
				SerializedProperty onChangedSP = property.FindPropertyRelative("OnChanged");
				if (onChangedSP != null)
				{
					position.y += EditorGUIUtility.singleLineHeight + GapVertical;
					position.x += EditorGUIUtility.labelWidth;
					position.width -= EditorGUIUtility.labelWidth;
					EditorGUI.PropertyField(position, onChangedSP, new GUIContent("OnChanged"), true);
					
				}
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
