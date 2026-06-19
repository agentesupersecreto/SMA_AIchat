using System;
using System.Globalization;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets.TValle.Pro.Entrevista.Runtime.Controlladores.Gestos;
using Assets.TValle.Pro.Entrevista.Runtime.UI.Modelaje.Modelos;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Modelaje
{
	// Token: 0x0200002A RID: 42
	[RequireComponent(typeof(GenericFlotanteUserPanel))]
	public class PanelDeEditarGestosFaciales : PanelBaseSingleModel<GestosFacialesShapesToEdit>
	{
		// Token: 0x060001A5 RID: 421 RVA: 0x00009A84 File Offset: 0x00007C84
		public void SetTarget(FemaleChar Target)
		{
			if (Target == null)
			{
				throw new ArgumentNullException("Target", "Target null reference.");
			}
			this.m_target = Target;
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x00009AA8 File Offset: 0x00007CA8
		protected override void OnBinding()
		{
			base.OnBinding();
			this.m_CustomGestosDeModelaje = this.m_target.GetComponentEnRoot<CustomGestosDeModelaje>();
			if (this.m_CustomGestosDeModelaje == null)
			{
				throw new ArgumentNullException("m_CustomGestosDeModelaje", "m_CustomGestosDeModelaje null reference.");
			}
			DatosDeHumanBone head = this.m_target.bones.head;
			base.transform.SetPositionAndRotation(head.posicionFinal, head.rotacionFinal * head.offSetToForward);
			this.m_follower = base.gameObject.AddComponent<TrasnformCopier>();
			this.m_follower.Init(false, base.transform, this.m_target.bones.head.transform, new Vector3?(head.offSetToForward.eulerAngles), null, null);
			this.m_CustomGestosDeModelaje.StartGestos();
			this.LoadValoresAModelo();
			this.m_model.onModelChanged += this.M_model_onModelChanged;
			this.m_model.accion1 += this.M_model_accion1;
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x00009BB8 File Offset: 0x00007DB8
		private void M_model_onModelChanged(IUIElementoConValor obj, IUIPanel panel)
		{
			float num = Convert.ToSingle(obj.GetValor(), CultureInfo.InvariantCulture);
			this.m_CustomGestosDeModelaje.ChangeGesto(obj.modelName, num);
			if (panel.modelType == this.m_model.jaw.GetType())
			{
				base.ActualizarValoresDeModelo();
				this.m_CustomGestosDeModelaje.ChangeGesto("ExpresionTongue_Curl_U__RL_14__", this.m_model.tongue.ExpresionTongue_Curl_U__RL_14__);
				this.m_CustomGestosDeModelaje.ChangeGesto("ExpresionTongue_Curl_D__RL_15__", this.m_model.tongue.ExpresionTongue_Curl_D__RL_15__);
				this.m_CustomGestosDeModelaje.ChangeGesto("ExpresionTongue_up__RL_9__", this.m_model.tongue.ExpresionTongue_up__RL_9__);
				this.m_CustomGestosDeModelaje.ChangeGesto("ExpresionTongue_Narrow__RL_12__", this.m_model.tongue.ExpresionTongue_Narrow__RL_12__);
				this.m_CustomGestosDeModelaje.ChangeGesto("ExpresionTongue_Out__RL_11__", this.m_model.tongue.ExpresionTongue_Out__RL_11__);
				this.m_CustomGestosDeModelaje.ChangeGesto("ExpresionTongue_Raise__RL_10__", this.m_model.tongue.ExpresionTongue_Raise__RL_10__);
				this.m_CustomGestosDeModelaje.ChangeGesto("ExpresionTongue_Lower__RL_13__", this.m_model.tongue.ExpresionTongue_Lower__RL_13__);
			}
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x00009CEE File Offset: 0x00007EEE
		private void M_model_accion1()
		{
			base.Clear();
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00009CF8 File Offset: 0x00007EF8
		protected override void OnCleared()
		{
			base.OnCleared();
			this.m_model.onModelChanged -= this.M_model_onModelChanged;
			this.m_model.accion1 -= this.M_model_accion1;
			this.m_target = null;
			this.m_CustomGestosDeModelaje = null;
			if (this.m_follower != null)
			{
				Object.Destroy(this.m_follower);
			}
			this.m_follower = null;
		}

		// Token: 0x060001AA RID: 426 RVA: 0x00009D68 File Offset: 0x00007F68
		private void LoadValoresAModelo()
		{
			this.m_model.mouth.Expresion_Mouth_Open__RL_44__ = this.m_CustomGestosDeModelaje.Expresion_Mouth_Open__RL_44__Mod.valor.valor;
			this.m_model.mouth.Expresion_Open__RL_1__ = this.m_CustomGestosDeModelaje.Expresion_Open__RL_1__Mod.valor.valor;
			this.m_model.mouth.Expresion_Explosive__RL_2__ = this.m_CustomGestosDeModelaje.Expresion_Explosive__RL_2__Mod.valor.valor;
			this.m_model.mouth.Expresion_Tight_O__RL_4__ = this.m_CustomGestosDeModelaje.Expresion_Tight_O__RL_4__Mod.valor.valor;
			this.m_model.mouth.Expresion_Wide__RL_6__ = this.m_CustomGestosDeModelaje.Expresion_Wide__RL_6__Mod.valor.valor;
			this.m_model.mouth.Expresion_Tight__RL_5__ = this.m_CustomGestosDeModelaje.Expresion_Tight__RL_5__Mod.valor.valor;
			this.m_model.mouth.Expresion_Affricate__RL_7__ = this.m_CustomGestosDeModelaje.Expresion_Affricate__RL_7__Mod.valor.valor;
			this.m_model.lips.Expresion_Lips_Drop_L_Side__RL_36__ = this.m_CustomGestosDeModelaje.Expresion_Lips_Drop_L_Side__RL_36__Mod.valor.valor;
			this.m_model.lips.Expresion_Lips_Drop__RL_26__ = this.m_CustomGestosDeModelaje.Expresion_Lips_Drop__RL_26__Mod.valor.valor;
			this.m_model.lips.Expresion_Lip_Raise_Top__RL_45__ = this.m_CustomGestosDeModelaje.Expresion_Lip_Raise_Top__RL_45__Mod.valor.valor;
			this.m_model.lips.Expresion_Lip_Open__RL_8__ = this.m_CustomGestosDeModelaje.Expresion_Lip_Open__RL_8__Mod.valor.valor;
			this.m_model.lips.Expresion_Lips_Smirk_R__RL_33__ = this.m_CustomGestosDeModelaje.Expresion_Lips_Smirk_R__RL_33__Mod.valor.valor;
			this.m_model.lips.Expresion_Lips_Open__RL_51__ = this.m_CustomGestosDeModelaje.Expresion_Lips_Open__RL_51__Mod.valor.valor;
			this.m_model.lips.Expresion_Dental_Lip__RL_3__ = this.m_CustomGestosDeModelaje.Expresion_Dental_Lip__RL_3__Mod.valor.valor;
			this.m_model.lips.Expresion_Lips_Widen__RL_40__ = this.m_CustomGestosDeModelaje.Expresion_Lips_Widen__RL_40__Mod.valor.valor;
			this.m_model.lips.Expresion_Lips_Smirk_L__RL_32__ = this.m_CustomGestosDeModelaje.Expresion_Lips_Smirk_L__RL_32__Mod.valor.valor;
			this.m_model.lips.Expresion_Lips_Drop_Sides__RL_35__ = this.m_CustomGestosDeModelaje.Expresion_Lips_Drop_Sides__RL_35__Mod.valor.valor;
			this.m_model.lips.Expresion_Lips_Smirk__RL_31__ = this.m_CustomGestosDeModelaje.Expresion_Lips_Smirk__RL_31__Mod.valor.valor;
			this.m_model.lips.Expresion_Lips_Puckered_Open__RL_41__ = this.m_CustomGestosDeModelaje.Expresion_Lips_Puckered_Open__RL_41__Mod.valor.valor;
			this.m_model.lips.Expresion_Lips_Jut_Open__RL_39__ = this.m_CustomGestosDeModelaje.Expresion_Lips_Jut_Open__RL_39__Mod.valor.valor;
			this.m_model.lips.Expresion_Lips_Zipped_Tight__RL_43__ = this.m_CustomGestosDeModelaje.Expresion_Lips_Zipped_Tight__RL_43__Mod.valor.valor;
			this.m_model.lips.Expresion_Lips_Drop_R_Side__RL_37__ = this.m_CustomGestosDeModelaje.Expresion_Lips_Drop_R_Side__RL_37__Mod.valor.valor;
			this.m_model.lips.Expresion_Lips_Widen_Sides__RL_34__ = this.m_CustomGestosDeModelaje.Expresion_Lips_Widen_Sides__RL_34__Mod.valor.valor;
			this.m_model.lips.Expresion_Lips_Tuck__RL_46__ = this.m_CustomGestosDeModelaje.Expresion_Lips_Tuck__RL_46__Mod.valor.valor;
			this.m_model.eyes.Expresion_Eye_Blink_L__RL_49__ = this.m_CustomGestosDeModelaje.Expresion_Eye_Blink_L__RL_49__Mod.valor.valor;
			this.m_model.eyes.Expresion_Eyes_Blink__RL_48__ = this.m_CustomGestosDeModelaje.Expresion_Eyes_Blink__RL_48__Mod.valor.valor;
			this.m_model.eyes.Expresion_Eyelids_Enlarge__RL_42__ = this.m_CustomGestosDeModelaje.Expresion_Eyelids_Enlarge__RL_42__Mod.valor.valor;
			this.m_model.eyes.Expresion_Eye_Blink_R__RL_50__ = this.m_CustomGestosDeModelaje.Expresion_Eye_Blink_R__RL_50__Mod.valor.valor;
			this.m_model.eyes.Expresion_Eyes_Squint__RL_47__ = this.m_CustomGestosDeModelaje.Expresion_Eyes_Squint__RL_47__Mod.valor.valor;
			this.m_model.nose.Expresion_Nose_Flank_Raise__RL_30__ = this.m_CustomGestosDeModelaje.Expresion_Nose_Flank_Raise__RL_30__Mod.valor.valor;
			this.m_model.nose.Expresion_Nose_Flank_Raise_L__RL_28__ = this.m_CustomGestosDeModelaje.Expresion_Nose_Flank_Raise_L__RL_28__Mod.valor.valor;
			this.m_model.nose.Expresion_Nose_Scrunch__RL_27__ = this.m_CustomGestosDeModelaje.Expresion_Nose_Scrunch__RL_27__Mod.valor.valor;
			this.m_model.nose.Expresion_Nose_Flank_Raise_R__RL_29__ = this.m_CustomGestosDeModelaje.Expresion_Nose_Flank_Raise_R__RL_29__Mod.valor.valor;
			this.m_model.cheeksAndChin.Expresion_Cheek_Raise_L__RL_24__ = this.m_CustomGestosDeModelaje.Expresion_Cheek_Raise_L__RL_24__Mod.valor.valor;
			this.m_model.cheeksAndChin.Expresion_Cheek_Raise_R__RL_25__ = this.m_CustomGestosDeModelaje.Expresion_Cheek_Raise_R__RL_25__Mod.valor.valor;
			this.m_model.cheeksAndChin.Expresion_Chin_Raise__RL_38__ = this.m_CustomGestosDeModelaje.Expresion_Chin_Raise__RL_38__Mod.valor.valor;
			this.m_model.jaw.Expresion_Jaw_Move_D__RL_61__Exprecion = this.m_CustomGestosDeModelaje.Expresion_Jaw_Move_D__RL_61__ExprecionMod.valor.valor;
			this.m_model.jaw.Expresion_Jaw_Rotate_D__RL_58__ = this.m_CustomGestosDeModelaje.Expresion_Jaw_Rotate_D__RL_58__Mod.valor.valor;
			this.m_model.jaw.x = this.m_CustomGestosDeModelaje.JawXMod.valor.valor;
			this.m_model.eyeBrows.Expresion_Brow_Raise_R__RL_23__ = this.m_CustomGestosDeModelaje.Expresion_Brow_Raise_R__RL_23__Mod.valor.valor;
			this.m_model.eyeBrows.Expresion_Brow_Raise_Outer_L__RL_18__ = this.m_CustomGestosDeModelaje.Expresion_Brow_Raise_Outer_L__RL_18__Mod.valor.valor;
			this.m_model.eyeBrows.Expresion_Brow_Raise_Inner_R__RL_17__ = this.m_CustomGestosDeModelaje.Expresion_Brow_Raise_Inner_R__RL_17__Mod.valor.valor;
			this.m_model.eyeBrows.Expresion_Brow_Raise_Outer_R__RL_19__ = this.m_CustomGestosDeModelaje.Expresion_Brow_Raise_Outer_R__RL_19__Mod.valor.valor;
			this.m_model.eyeBrows.Expresion_Brow_Drop_R__RL_21__ = this.m_CustomGestosDeModelaje.Expresion_Brow_Drop_R__RL_21__Mod.valor.valor;
			this.m_model.eyeBrows.Expresion_Brow_Raise_Inner_L__RL_16__ = this.m_CustomGestosDeModelaje.Expresion_Brow_Raise_Inner_L__RL_16__Mod.valor.valor;
			this.m_model.eyeBrows.Expresion_Brow_Raise_L__RL_22__ = this.m_CustomGestosDeModelaje.Expresion_Brow_Raise_L__RL_22__Mod.valor.valor;
			this.m_model.eyeBrows.Expresion_Brow_Drop_L__RL_20__ = this.m_CustomGestosDeModelaje.Expresion_Brow_Drop_L__RL_20__Mod.valor.valor;
			this.m_model.tongue.ExpresionTongue_Curl_U__RL_14__ = this.m_CustomGestosDeModelaje.ExpresionTongue_Curl_U__RL_14__Mod.valor.valor;
			this.m_model.tongue.ExpresionTongue_Curl_D__RL_15__ = this.m_CustomGestosDeModelaje.ExpresionTongue_Curl_D__RL_15__Mod.valor.valor;
			this.m_model.tongue.ExpresionTongue_up__RL_9__ = this.m_CustomGestosDeModelaje.ExpresionTongue_up__RL_9__Mod.valor.valor;
			this.m_model.tongue.ExpresionTongue_Narrow__RL_12__ = this.m_CustomGestosDeModelaje.ExpresionTongue_Narrow__RL_12__Mod.valor.valor;
			this.m_model.tongue.ExpresionTongue_Out__RL_11__ = this.m_CustomGestosDeModelaje.ExpresionTongue_Out__RL_11__Mod.valor.valor;
			this.m_model.tongue.ExpresionTongue_Raise__RL_10__ = this.m_CustomGestosDeModelaje.ExpresionTongue_Raise__RL_10__Mod.valor.valor;
			this.m_model.tongue.ExpresionTongue_Lower__RL_13__ = this.m_CustomGestosDeModelaje.ExpresionTongue_Lower__RL_13__Mod.valor.valor;
		}

		// Token: 0x040000F3 RID: 243
		[SerializeField]
		[ReadOnlyUI]
		private FemaleChar m_target;

		// Token: 0x040000F4 RID: 244
		[SerializeField]
		[ReadOnlyUI]
		private CustomGestosDeModelaje m_CustomGestosDeModelaje;

		// Token: 0x040000F5 RID: 245
		[SerializeField]
		[ReadOnlyUI]
		private TrasnformCopier m_follower;
	}
}
