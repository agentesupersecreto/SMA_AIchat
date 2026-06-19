using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace NodeEditorFramework
{
	// Token: 0x02000097 RID: 151
	public static class NodeTypes
	{
		// Token: 0x0600048C RID: 1164 RVA: 0x00014104 File Offset: 0x00012304
		public static void FetchNodes()
		{
			NodeTypes.nodes = new Dictionary<Node, NodeData>();
			List<Assembly> list = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
				where assembly.FullName.Contains("Assembly")
				select assembly).ToList<Assembly>();
			if (!list.Contains(Assembly.GetExecutingAssembly()))
			{
				list.Add(Assembly.GetExecutingAssembly());
			}
			foreach (Assembly assembly2 in list)
			{
				foreach (Type type in from T in assembly2.GetTypes()
					where T.IsClass && !T.IsAbstract && T.IsSubclassOf(typeof(Node))
					select T)
				{
					object[] customAttributes = type.GetCustomAttributes(typeof(NodeAttribute), false);
					if (customAttributes != null && customAttributes.Length != 0)
					{
						NodeAttribute nodeAttribute = customAttributes[0] as NodeAttribute;
						if (nodeAttribute == null || !nodeAttribute.hide)
						{
							Node node = ScriptableObject.CreateInstance(type) as Node;
							node = node.Create(Vector2.zero);
							NodeTypes.nodes.Add(node, new NodeData((nodeAttribute == null) ? node.name : nodeAttribute.contextText));
						}
					}
				}
			}
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x00014278 File Offset: 0x00012478
		public static NodeData getNodeData(Node node)
		{
			return NodeTypes.nodes[NodeTypes.getDefaultNode(node.GetID)];
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x00014290 File Offset: 0x00012490
		public static Node getDefaultNode(string nodeID)
		{
			return NodeTypes.nodes.Keys.Single((Node node) => node.GetID == nodeID);
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x000142C5 File Offset: 0x000124C5
		public static T getDefaultNode<T>() where T : Node
		{
			return NodeTypes.nodes.Keys.Single((Node node) => node.GetType() == typeof(T)) as T;
		}

		// Token: 0x0400012C RID: 300
		public static Dictionary<Node, NodeData> nodes;
	}
}
