using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts.Controllers;
using Assets._ReusableScripts.CuchiCuchi._CharactersBasics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Chars.Controladores
{
	// Token: 0x02000138 RID: 312
	public sealed class ControladorDeJawV2 : ControllerMultipleDirectoModificableDeUnSoloFloat, IControladorDeJaw, IControladorDirecto, IComponentStartable
	{
		// Token: 0x170004BB RID: 1211
		// (get) Token: 0x06000D78 RID: 3448 RVA: 0x0002EAFA File Offset: 0x0002CCFA
		protected override int cantidadDeTipos
		{
			get
			{
				return 3;
			}
		}

		// Token: 0x170004BC RID: 1212
		// (get) Token: 0x06000D79 RID: 3449 RVA: 0x0002EAFD File Offset: 0x0002CCFD
		protected override ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeValor valorActualSeModificaComo
		{
			get
			{
				return ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeValor.bajaPrioridad;
			}
		}

		// Token: 0x170004BD RID: 1213
		// (get) Token: 0x06000D7A RID: 3450 RVA: 0x0002EB00 File Offset: 0x0002CD00
		public bool estaObstruido
		{
			get
			{
				return this.m_bocaHole.isPenetrated;
			}
		}

		// Token: 0x170004BE RID: 1214
		// (get) Token: 0x06000D7B RID: 3451 RVA: 0x0002EB0D File Offset: 0x0002CD0D
		public Vector3 animationAngles
		{
			get
			{
				return this.m_animationAngles;
			}
		}

		// Token: 0x170004BF RID: 1215
		// (get) Token: 0x06000D7C RID: 3452 RVA: 0x0002EB15 File Offset: 0x0002CD15
		public Vector3 controlladorAngles
		{
			get
			{
				return this.m_controlladorAngles;
			}
		}

		// Token: 0x06000D7D RID: 3453 RVA: 0x0002EB20 File Offset: 0x0002CD20
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_updater = this.GetComponentEnRoot(false);
			this.m_character = this.GetComponentEnRoot(false);
			if (this.m_character == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
			if (this.m_updater == null)
			{
				throw new ArgumentNullException("m_updater", "m_updater null reference.");
			}
			this.m_bocaHole = this.GetComponentEnRoot(false);
			if (this.m_bocaHole == null)
			{
				throw new ArgumentNullException("m_bocaHole", "m_bocaHole null reference.");
			}
			this.m_character.stared += this.M_character_stared;
		}

		// Token: 0x06000D7E RID: 3454 RVA: 0x0002EBBF File Offset: 0x0002CDBF
		private void M_character_stared(object obj)
		{
			base.DoStart();
		}

		// Token: 0x06000D7F RID: 3455 RVA: 0x0002EBC7 File Offset: 0x0002CDC7
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_updater.onAllIKsUpdated += this.AfterIks;
			this.m_updater.onFixingTransforms += this.M_updater_iKsFixedTransforms;
		}

		// Token: 0x06000D80 RID: 3456 RVA: 0x0002EBFD File Offset: 0x0002CDFD
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_updater != null)
			{
				this.m_updater.onAllIKsUpdated -= this.AfterIks;
				this.m_updater.onFixingTransforms -= this.M_updater_iKsFixedTransforms;
			}
		}

		// Token: 0x06000D81 RID: 3457 RVA: 0x0002EC3C File Offset: 0x0002CE3C
		private void M_updater_iKsFixedTransforms(IIKUpdater obj)
		{
			if (this.m_character == null)
			{
				return;
			}
			base.FixValues();
		}

		// Token: 0x06000D82 RID: 3458 RVA: 0x0002EC53 File Offset: 0x0002CE53
		private void AfterIks(IIKUpdater obj)
		{
			if (this.m_character == null)
			{
				return;
			}
			base.DoUpdate();
		}

		// Token: 0x06000D83 RID: 3459 RVA: 0x0002EC6A File Offset: 0x0002CE6A
		protected override void Updating()
		{
			this.m_animationAngles = this.m_character.bones.jaw.currentRotationAnglesDesdeHead;
		}

		// Token: 0x06000D84 RID: 3460 RVA: 0x0002EC88 File Offset: 0x0002CE88
		protected override void ActualizarValor(int index, ControllerMultipleDirectoModificableDeUnSoloFloat.Valor valor)
		{
			switch (index)
			{
			case 0:
				valor.valor = this.m_animationAngles.x;
				return;
			case 1:
				valor.valor = this.m_animationAngles.y;
				return;
			case 2:
				valor.valor = this.m_animationAngles.z;
				return;
			default:
				throw new ArgumentOutOfRangeException(index.ToString());
			}
		}

		// Token: 0x06000D85 RID: 3461 RVA: 0x0002ECEC File Offset: 0x0002CEEC
		protected override void SetValues(Dictionary<int, ControllerMultipleDirectoModificableDeUnSoloFloat.Resultado> diccResultados, List<ControllerMultipleDirectoModificableDeUnSoloFloat.Resultado> resultados)
		{
			float valor = resultados[0].valor;
			float valor2 = resultados[1].valor;
			float valor3 = resultados[2].valor;
			if (Application.isEditor)
			{
				if (float.IsNaN(valor) || float.IsInfinity(valor))
				{
					Debug.LogError("x value de controllador fue invalido " + valor.ToString(), this);
					Debug.Break();
					return;
				}
				if (float.IsNaN(valor2) || float.IsInfinity(valor2))
				{
					Debug.LogError("y value de controllador fue invalido " + valor2.ToString(), this);
					Debug.Break();
					return;
				}
				if (float.IsNaN(valor3) || float.IsInfinity(valor3))
				{
					Debug.LogError("z value de controllador fue invalido " + valor3.ToString(), this);
					Debug.Break();
					return;
				}
			}
			Vector3 vector = new Vector3(valor.ToEuler(), valor2.ToEuler(), valor3.ToEuler());
			this.m_character.bones.jaw.currentRotationAnglesDesdeHead = vector;
		}

		// Token: 0x06000D86 RID: 3462 RVA: 0x0002EDE0 File Offset: 0x0002CFE0
		protected override void Updated()
		{
			this.m_controlladorAngles = this.m_character.bones.jaw.currentRotationAnglesDesdeHead;
		}

		// Token: 0x06000D87 RID: 3463 RVA: 0x0002EDFD File Offset: 0x0002CFFD
		public override string KeyDeIndex(int index)
		{
			switch (index)
			{
			case 0:
				return "x";
			case 1:
				return "y";
			case 2:
				return "z";
			default:
				throw new ArgumentOutOfRangeException(index.ToString());
			}
		}

		// Token: 0x06000D88 RID: 3464 RVA: 0x0002EE31 File Offset: 0x0002D031
		public override int IndexDeKey(string key)
		{
			if (key == "x")
			{
				return 0;
			}
			if (key == "y")
			{
				return 1;
			}
			if (!(key == "z"))
			{
				throw new ArgumentOutOfRangeException(key);
			}
			return 2;
		}

		// Token: 0x06000D89 RID: 3465 RVA: 0x0002EE68 File Offset: 0x0002D068
		protected override void SetDefaultValues()
		{
			this.m_character.bones.jaw.currentRotationAnglesDesdeHead = Vector3.zero;
		}

		// Token: 0x06000D8A RID: 3466 RVA: 0x0002EE84 File Offset: 0x0002D084
		protected override float ValorPorDefectoDeIndex(int index)
		{
			return 0f;
		}

		// Token: 0x04000784 RID: 1924
		private IIKUpdater m_updater;

		// Token: 0x04000785 RID: 1925
		private AnimatorCharacter m_character;

		// Token: 0x04000786 RID: 1926
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_animationAngles;

		// Token: 0x04000787 RID: 1927
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_controlladorAngles;

		// Token: 0x04000788 RID: 1928
		private IBocaHole m_bocaHole;

		// Token: 0x02000209 RID: 521
		public enum Axis
		{
			// Token: 0x04000B25 RID: 2853
			x,
			// Token: 0x04000B26 RID: 2854
			y,
			// Token: 0x04000B27 RID: 2855
			z
		}
	}
}
