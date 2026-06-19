using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Assets.Scripts.Testing
{
	// Token: 0x02000043 RID: 67
	public class CompararBindPoses : AplicableCustomMonobehaviour
	{
		// Token: 0x06000146 RID: 326 RVA: 0x0000B804 File Offset: 0x00009A04
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			if (this.m_a == this.m_b || this.m_a.sharedMesh == this.m_b.sharedMesh)
			{
				throw new InvalidOperationException();
			}
			IEnumerable<Transform> bones = this.m_a.bones;
			Transform[] bones2 = this.m_b.bones;
			Matrix4x4[] bindPosesA = this.m_a.sharedMesh.bindposes;
			Matrix4x4[] bindPosesB = this.m_b.sharedMesh.bindposes;
			Dictionary<string, ValueTuple<Transform, Matrix4x4>> dictionary = bones.Select((Transform b, int i) => new ValueTuple<Transform, Matrix4x4>(b, bindPosesA[i])).ToDictionary(([TupleElementNames(new string[] { "b", null })] ValueTuple<Transform, Matrix4x4> par) => par.Item1.name);
			Dictionary<string, ValueTuple<Transform, Matrix4x4>> dictionary2 = bones2.Select((Transform b, int i) => new ValueTuple<Transform, Matrix4x4>(b, bindPosesB[i])).ToDictionary(([TupleElementNames(new string[] { "b", null })] ValueTuple<Transform, Matrix4x4> par) => par.Item1.name);
			foreach (KeyValuePair<string, ValueTuple<Transform, Matrix4x4>> keyValuePair in dictionary)
			{
				string key = keyValuePair.Key;
				ValueTuple<Transform, Matrix4x4> valueTuple;
				if (dictionary2.TryGetValue(key, out valueTuple))
				{
					Matrix4x4 item = keyValuePair.Value.Item2;
					Matrix4x4 item2 = valueTuple.Item2;
					Vector3 vector = item.MultiplyPoint3x4(Vector3.zero);
					Vector3 vector2 = item2.MultiplyPoint3x4(Vector3.zero);
					Quaternion quaternion = Quaternion.LookRotation(item.MultiplyVector(Vector3.forward), item.MultiplyVector(Vector3.up));
					Quaternion quaternion2 = Quaternion.LookRotation(item2.MultiplyVector(Vector3.forward), item2.MultiplyVector(Vector3.up));
					Vector3 lossyScale = item.lossyScale;
					Vector3 lossyScale2 = item2.lossyScale;
					Debug.Log(string.Concat(new string[]
					{
						"bone: |",
						key,
						"| Position offset: |",
						Vector3.Distance(vector, vector2).ToString(),
						"| Rotation offset: |",
						Quaternion.Angle(quaternion, quaternion2).ToString(),
						"| Scale offset: |",
						Mathf.Abs(lossyScale.Escala() - lossyScale2.Escala()).ToString(),
						"| ."
					}));
				}
			}
		}

		// Token: 0x06000147 RID: 327 RVA: 0x0000BA74 File Offset: 0x00009C74
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Comparar",
				playTimeVisible = false
			};
		}

		// Token: 0x040000B5 RID: 181
		[SerializeField]
		private SkinnedMeshRenderer m_a;

		// Token: 0x040000B6 RID: 182
		[SerializeField]
		private SkinnedMeshRenderer m_b;
	}
}
