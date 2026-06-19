using System;
using System.Collections.Generic;
using Assets._ReusableScripts.Controllers;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Characters.Controladores.BajoNivel
{
	// Token: 0x02000121 RID: 289
	public class ControladorDeBaseDeLengua : ControllerMultipleDirectoModificableDeUnSoloFloat, IControladorDeBaseDeLengua, IControladorDirecto, IComponentStartable
	{
		// Token: 0x17000487 RID: 1159
		// (get) Token: 0x06000C88 RID: 3208 RVA: 0x0002AAC4 File Offset: 0x00028CC4
		protected override int cantidadDeTipos
		{
			get
			{
				return 3;
			}
		}

		// Token: 0x17000488 RID: 1160
		// (get) Token: 0x06000C89 RID: 3209 RVA: 0x0002AAC7 File Offset: 0x00028CC7
		protected override ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeValor valorActualSeModificaComo
		{
			get
			{
				return ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeValor.bajaPrioridad;
			}
		}

		// Token: 0x06000C8A RID: 3210 RVA: 0x0002AACC File Offset: 0x00028CCC
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
			this.m_character.stared += this.M_character_stared;
		}

		// Token: 0x06000C8B RID: 3211 RVA: 0x0002AB46 File Offset: 0x00028D46
		private void M_character_stared(object obj)
		{
			base.DoStart();
			DatosDeLengua lenguaBase = this.m_character.bones.lenguaBase;
			if (((lenguaBase != null) ? lenguaBase.transform : null) == null)
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x06000C8C RID: 3212 RVA: 0x0002AB78 File Offset: 0x00028D78
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_updater.onAllIKsUpdated += this.AfterIks;
			this.m_updater.onFixingTransforms += this.M_updater_iKsFixedTransforms;
		}

		// Token: 0x06000C8D RID: 3213 RVA: 0x0002ABAE File Offset: 0x00028DAE
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_updater != null)
			{
				this.m_updater.onAllIKsUpdated -= this.AfterIks;
				this.m_updater.onFixingTransforms -= this.M_updater_iKsFixedTransforms;
			}
		}

		// Token: 0x06000C8E RID: 3214 RVA: 0x0002ABED File Offset: 0x00028DED
		private void M_updater_iKsFixedTransforms(IIKUpdater obj)
		{
			if (this.m_character == null)
			{
				return;
			}
			base.FixValues();
		}

		// Token: 0x06000C8F RID: 3215 RVA: 0x0002AC04 File Offset: 0x00028E04
		private void AfterIks(IIKUpdater obj)
		{
			if (this.m_character == null)
			{
				return;
			}
			base.DoUpdate();
		}

		// Token: 0x06000C90 RID: 3216 RVA: 0x0002AC1B File Offset: 0x00028E1B
		protected override void Updating()
		{
			this.m_animationAngles = this.m_character.bones.lenguaBase.currentRotationAnglesDesdeJaw;
		}

		// Token: 0x06000C91 RID: 3217 RVA: 0x0002AC38 File Offset: 0x00028E38
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

		// Token: 0x06000C92 RID: 3218 RVA: 0x0002AC9C File Offset: 0x00028E9C
		protected override void SetValues(Dictionary<int, ControllerMultipleDirectoModificableDeUnSoloFloat.Resultado> diccResultados, List<ControllerMultipleDirectoModificableDeUnSoloFloat.Resultado> resultados)
		{
			Vector3 vector = new Vector3(resultados[0].valor, resultados[1].valor, resultados[2].valor);
			this.m_character.bones.lenguaBase.currentRotationAnglesDesdeJaw = vector;
		}

		// Token: 0x06000C93 RID: 3219 RVA: 0x0002ACEA File Offset: 0x00028EEA
		protected override void Updated()
		{
			this.m_controlladorAngles = this.m_character.bones.lenguaBase.currentRotationAnglesDesdeJaw;
		}

		// Token: 0x06000C94 RID: 3220 RVA: 0x0002AD07 File Offset: 0x00028F07
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

		// Token: 0x06000C95 RID: 3221 RVA: 0x0002AD3B File Offset: 0x00028F3B
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

		// Token: 0x06000C96 RID: 3222 RVA: 0x0002AD72 File Offset: 0x00028F72
		protected override void SetDefaultValues()
		{
			this.m_character.bones.lenguaBase.currentRotationAnglesDesdeJaw = Vector3.zero;
		}

		// Token: 0x06000C97 RID: 3223 RVA: 0x0002AD8E File Offset: 0x00028F8E
		protected override float ValorPorDefectoDeIndex(int index)
		{
			return 0f;
		}

		// Token: 0x040006B3 RID: 1715
		private IIKUpdater m_updater;

		// Token: 0x040006B4 RID: 1716
		private AnimatorCharacter m_character;

		// Token: 0x040006B5 RID: 1717
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_animationAngles;

		// Token: 0x040006B6 RID: 1718
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_controlladorAngles;
	}
}
