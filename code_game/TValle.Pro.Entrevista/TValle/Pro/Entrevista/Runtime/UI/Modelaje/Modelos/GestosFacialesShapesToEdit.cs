using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets.TValle.Pro.Entrevista.Runtime.Controlladores.Gestos;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Chars.Controladores;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Modelaje.Modelos
{
	// Token: 0x0200002E RID: 46
	[Modelo]
	[Label("Facial Gestures Editor", "US", alignment = TextAlignmentOptions.MidlineRight, fontStyle = FontStyles.Bold, fontSizeMod = 1.25f)]
	[Panel(width = 475, height = 900)]
	[Serializable]
	public class GestosFacialesShapesToEdit
	{
		// Token: 0x060001C2 RID: 450 RVA: 0x0000ABA4 File Offset: 0x00008DA4
		public static void LoadToCustomGestos(GestosFacialesShapesToEdit m_model, CustomGestosDeModelaje customGestosDeModelaje)
		{
			customGestosDeModelaje.Expresion_Mouth_Open__RL_44__Mod.valor.valor = m_model.mouth.Expresion_Mouth_Open__RL_44__;
			customGestosDeModelaje.Expresion_Open__RL_1__Mod.valor.valor = m_model.mouth.Expresion_Open__RL_1__;
			customGestosDeModelaje.Expresion_Explosive__RL_2__Mod.valor.valor = m_model.mouth.Expresion_Explosive__RL_2__;
			customGestosDeModelaje.Expresion_Tight_O__RL_4__Mod.valor.valor = m_model.mouth.Expresion_Tight_O__RL_4__;
			customGestosDeModelaje.Expresion_Wide__RL_6__Mod.valor.valor = m_model.mouth.Expresion_Wide__RL_6__;
			customGestosDeModelaje.Expresion_Tight__RL_5__Mod.valor.valor = m_model.mouth.Expresion_Tight__RL_5__;
			customGestosDeModelaje.Expresion_Affricate__RL_7__Mod.valor.valor = m_model.mouth.Expresion_Affricate__RL_7__;
			customGestosDeModelaje.Expresion_Lips_Drop_L_Side__RL_36__Mod.valor.valor = m_model.lips.Expresion_Lips_Drop_L_Side__RL_36__;
			customGestosDeModelaje.Expresion_Lips_Drop__RL_26__Mod.valor.valor = m_model.lips.Expresion_Lips_Drop__RL_26__;
			customGestosDeModelaje.Expresion_Lip_Raise_Top__RL_45__Mod.valor.valor = m_model.lips.Expresion_Lip_Raise_Top__RL_45__;
			customGestosDeModelaje.Expresion_Lip_Open__RL_8__Mod.valor.valor = m_model.lips.Expresion_Lip_Open__RL_8__;
			customGestosDeModelaje.Expresion_Lips_Smirk_R__RL_33__Mod.valor.valor = m_model.lips.Expresion_Lips_Smirk_R__RL_33__;
			customGestosDeModelaje.Expresion_Lips_Open__RL_51__Mod.valor.valor = m_model.lips.Expresion_Lips_Open__RL_51__;
			customGestosDeModelaje.Expresion_Dental_Lip__RL_3__Mod.valor.valor = m_model.lips.Expresion_Dental_Lip__RL_3__;
			customGestosDeModelaje.Expresion_Lips_Widen__RL_40__Mod.valor.valor = m_model.lips.Expresion_Lips_Widen__RL_40__;
			customGestosDeModelaje.Expresion_Lips_Smirk_L__RL_32__Mod.valor.valor = m_model.lips.Expresion_Lips_Smirk_L__RL_32__;
			customGestosDeModelaje.Expresion_Lips_Drop_Sides__RL_35__Mod.valor.valor = m_model.lips.Expresion_Lips_Drop_Sides__RL_35__;
			customGestosDeModelaje.Expresion_Lips_Smirk__RL_31__Mod.valor.valor = m_model.lips.Expresion_Lips_Smirk__RL_31__;
			customGestosDeModelaje.Expresion_Lips_Puckered_Open__RL_41__Mod.valor.valor = m_model.lips.Expresion_Lips_Puckered_Open__RL_41__;
			customGestosDeModelaje.Expresion_Lips_Jut_Open__RL_39__Mod.valor.valor = m_model.lips.Expresion_Lips_Jut_Open__RL_39__;
			customGestosDeModelaje.Expresion_Lips_Zipped_Tight__RL_43__Mod.valor.valor = m_model.lips.Expresion_Lips_Zipped_Tight__RL_43__;
			customGestosDeModelaje.Expresion_Lips_Drop_R_Side__RL_37__Mod.valor.valor = m_model.lips.Expresion_Lips_Drop_R_Side__RL_37__;
			customGestosDeModelaje.Expresion_Lips_Widen_Sides__RL_34__Mod.valor.valor = m_model.lips.Expresion_Lips_Widen_Sides__RL_34__;
			customGestosDeModelaje.Expresion_Lips_Tuck__RL_46__Mod.valor.valor = m_model.lips.Expresion_Lips_Tuck__RL_46__;
			customGestosDeModelaje.Expresion_Eye_Blink_L__RL_49__Mod.valor.valor = m_model.eyes.Expresion_Eye_Blink_L__RL_49__;
			customGestosDeModelaje.Expresion_Eyes_Blink__RL_48__Mod.valor.valor = m_model.eyes.Expresion_Eyes_Blink__RL_48__;
			customGestosDeModelaje.Expresion_Eyelids_Enlarge__RL_42__Mod.valor.valor = m_model.eyes.Expresion_Eyelids_Enlarge__RL_42__;
			customGestosDeModelaje.Expresion_Eye_Blink_R__RL_50__Mod.valor.valor = m_model.eyes.Expresion_Eye_Blink_R__RL_50__;
			customGestosDeModelaje.Expresion_Eyes_Squint__RL_47__Mod.valor.valor = m_model.eyes.Expresion_Eyes_Squint__RL_47__;
			customGestosDeModelaje.Expresion_Nose_Flank_Raise__RL_30__Mod.valor.valor = m_model.nose.Expresion_Nose_Flank_Raise__RL_30__;
			customGestosDeModelaje.Expresion_Nose_Flank_Raise_L__RL_28__Mod.valor.valor = m_model.nose.Expresion_Nose_Flank_Raise_L__RL_28__;
			customGestosDeModelaje.Expresion_Nose_Scrunch__RL_27__Mod.valor.valor = m_model.nose.Expresion_Nose_Scrunch__RL_27__;
			customGestosDeModelaje.Expresion_Nose_Flank_Raise_R__RL_29__Mod.valor.valor = m_model.nose.Expresion_Nose_Flank_Raise_R__RL_29__;
			customGestosDeModelaje.Expresion_Cheek_Raise_L__RL_24__Mod.valor.valor = m_model.cheeksAndChin.Expresion_Cheek_Raise_L__RL_24__;
			customGestosDeModelaje.Expresion_Cheek_Raise_R__RL_25__Mod.valor.valor = m_model.cheeksAndChin.Expresion_Cheek_Raise_R__RL_25__;
			customGestosDeModelaje.Expresion_Chin_Raise__RL_38__Mod.valor.valor = m_model.cheeksAndChin.Expresion_Chin_Raise__RL_38__;
			customGestosDeModelaje.Expresion_Jaw_Move_D__RL_61__ExprecionMod.valor.valor = m_model.jaw.Expresion_Jaw_Move_D__RL_61__Exprecion;
			customGestosDeModelaje.Expresion_Jaw_Rotate_D__RL_58__Mod.valor.valor = m_model.jaw.Expresion_Jaw_Rotate_D__RL_58__;
			customGestosDeModelaje.Expresion_Brow_Raise_R__RL_23__Mod.valor.valor = m_model.eyeBrows.Expresion_Brow_Raise_R__RL_23__;
			customGestosDeModelaje.Expresion_Brow_Raise_Outer_L__RL_18__Mod.valor.valor = m_model.eyeBrows.Expresion_Brow_Raise_Outer_L__RL_18__;
			customGestosDeModelaje.Expresion_Brow_Raise_Inner_R__RL_17__Mod.valor.valor = m_model.eyeBrows.Expresion_Brow_Raise_Inner_R__RL_17__;
			customGestosDeModelaje.Expresion_Brow_Raise_Outer_R__RL_19__Mod.valor.valor = m_model.eyeBrows.Expresion_Brow_Raise_Outer_R__RL_19__;
			customGestosDeModelaje.Expresion_Brow_Drop_R__RL_21__Mod.valor.valor = m_model.eyeBrows.Expresion_Brow_Drop_R__RL_21__;
			customGestosDeModelaje.Expresion_Brow_Raise_Inner_L__RL_16__Mod.valor.valor = m_model.eyeBrows.Expresion_Brow_Raise_Inner_L__RL_16__;
			customGestosDeModelaje.Expresion_Brow_Raise_L__RL_22__Mod.valor.valor = m_model.eyeBrows.Expresion_Brow_Raise_L__RL_22__;
			customGestosDeModelaje.Expresion_Brow_Drop_L__RL_20__Mod.valor.valor = m_model.eyeBrows.Expresion_Brow_Drop_L__RL_20__;
			customGestosDeModelaje.ExpresionTongue_Curl_U__RL_14__Mod.valor.valor = m_model.tongue.ExpresionTongue_Curl_U__RL_14__;
			customGestosDeModelaje.ExpresionTongue_Curl_D__RL_15__Mod.valor.valor = m_model.tongue.ExpresionTongue_Curl_D__RL_15__;
			customGestosDeModelaje.ExpresionTongue_up__RL_9__Mod.valor.valor = m_model.tongue.ExpresionTongue_up__RL_9__;
			customGestosDeModelaje.ExpresionTongue_Narrow__RL_12__Mod.valor.valor = m_model.tongue.ExpresionTongue_Narrow__RL_12__;
			customGestosDeModelaje.ExpresionTongue_Out__RL_11__Mod.valor.valor = m_model.tongue.ExpresionTongue_Out__RL_11__;
			customGestosDeModelaje.ExpresionTongue_Raise__RL_10__Mod.valor.valor = m_model.tongue.ExpresionTongue_Raise__RL_10__;
			customGestosDeModelaje.ExpresionTongue_Lower__RL_13__Mod.valor.valor = m_model.tongue.ExpresionTongue_Lower__RL_13__;
			customGestosDeModelaje.JawXMod.valor.valor = m_model.jaw.x;
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x0000B164 File Offset: 0x00009364
		public static void LoadFromControllers(GestosFacialesShapesToEdit m_model, ControladorDeCCAnimationBlendShapes controller, ControladorDeJawV2 jawController)
		{
			m_model.mouth.Expresion_Mouth_Open__RL_44__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Mouth_Open__RL_44__"))].valor;
			m_model.mouth.Expresion_Open__RL_1__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Open__RL_1__"))].valor;
			m_model.mouth.Expresion_Explosive__RL_2__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Explosive__RL_2__"))].valor;
			m_model.mouth.Expresion_Tight_O__RL_4__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Tight_O__RL_4__"))].valor;
			m_model.mouth.Expresion_Wide__RL_6__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Wide__RL_6__"))].valor;
			m_model.mouth.Expresion_Tight__RL_5__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Tight__RL_5__"))].valor;
			m_model.mouth.Expresion_Affricate__RL_7__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Affricate__RL_7__"))].valor;
			m_model.lips.Expresion_Lips_Drop_L_Side__RL_36__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Lips_Drop_L_Side__RL_36__"))].valor;
			m_model.lips.Expresion_Lips_Drop__RL_26__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Lips_Drop__RL_26__"))].valor;
			m_model.lips.Expresion_Lip_Raise_Top__RL_45__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Lip_Raise_Top__RL_45__"))].valor;
			m_model.lips.Expresion_Lip_Open__RL_8__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Lip_Open__RL_8__"))].valor;
			m_model.lips.Expresion_Lips_Smirk_R__RL_33__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Lips_Smirk_R__RL_33__"))].valor;
			m_model.lips.Expresion_Lips_Open__RL_51__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Lips_Open__RL_51__"))].valor;
			m_model.lips.Expresion_Dental_Lip__RL_3__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Dental_Lip__RL_3__"))].valor;
			m_model.lips.Expresion_Lips_Widen__RL_40__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Lips_Widen__RL_40__"))].valor;
			m_model.lips.Expresion_Lips_Smirk_L__RL_32__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Lips_Smirk_L__RL_32__"))].valor;
			m_model.lips.Expresion_Lips_Drop_Sides__RL_35__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Lips_Drop_Sides__RL_35__"))].valor;
			m_model.lips.Expresion_Lips_Smirk__RL_31__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Lips_Smirk__RL_31__"))].valor;
			m_model.lips.Expresion_Lips_Puckered_Open__RL_41__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Lips_Puckered_Open__RL_41__"))].valor;
			m_model.lips.Expresion_Lips_Jut_Open__RL_39__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Lips_Jut_Open__RL_39__"))].valor;
			m_model.lips.Expresion_Lips_Zipped_Tight__RL_43__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Lips_Zipped_Tight__RL_43__"))].valor;
			m_model.lips.Expresion_Lips_Drop_R_Side__RL_37__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Lips_Drop_R_Side__RL_37__"))].valor;
			m_model.lips.Expresion_Lips_Widen_Sides__RL_34__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Lips_Widen_Sides__RL_34__"))].valor;
			m_model.lips.Expresion_Lips_Tuck__RL_46__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Lips_Tuck__RL_46__"))].valor;
			m_model.eyes.Expresion_Eye_Blink_L__RL_49__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Eye_Blink_L__RL_49__"))].valor;
			m_model.eyes.Expresion_Eyes_Blink__RL_48__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Eyes_Blink__RL_48__"))].valor;
			m_model.eyes.Expresion_Eyelids_Enlarge__RL_42__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Eyelids_Enlarge__RL_42__"))].valor;
			m_model.eyes.Expresion_Eye_Blink_R__RL_50__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Eye_Blink_R__RL_50__"))].valor;
			m_model.eyes.Expresion_Eyes_Squint__RL_47__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Eyes_Squint__RL_47__"))].valor;
			m_model.nose.Expresion_Nose_Flank_Raise__RL_30__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Nose_Flank_Raise__RL_30__"))].valor;
			m_model.nose.Expresion_Nose_Flank_Raise_L__RL_28__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Nose_Flank_Raise_L__RL_28__"))].valor;
			m_model.nose.Expresion_Nose_Scrunch__RL_27__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Nose_Scrunch__RL_27__"))].valor;
			m_model.nose.Expresion_Nose_Flank_Raise_R__RL_29__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Nose_Flank_Raise_R__RL_29__"))].valor;
			m_model.cheeksAndChin.Expresion_Cheek_Raise_L__RL_24__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Cheek_Raise_L__RL_24__"))].valor;
			m_model.cheeksAndChin.Expresion_Cheek_Raise_R__RL_25__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Cheek_Raise_R__RL_25__"))].valor;
			m_model.cheeksAndChin.Expresion_Chin_Raise__RL_38__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Chin_Raise__RL_38__"))].valor;
			m_model.jaw.Expresion_Jaw_Move_D__RL_61__Exprecion = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Jaw_Move_D__RL_61__Exprecion"))].valor;
			m_model.jaw.Expresion_Jaw_Rotate_D__RL_58__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Jaw_Rotate_D__RL_58__"))].valor;
			m_model.eyeBrows.Expresion_Brow_Raise_R__RL_23__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Brow_Raise_R__RL_23__"))].valor;
			m_model.eyeBrows.Expresion_Brow_Raise_Outer_L__RL_18__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Brow_Raise_Outer_L__RL_18__"))].valor;
			m_model.eyeBrows.Expresion_Brow_Raise_Inner_R__RL_17__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Brow_Raise_Inner_R__RL_17__"))].valor;
			m_model.eyeBrows.Expresion_Brow_Raise_Outer_R__RL_19__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Brow_Raise_Outer_R__RL_19__"))].valor;
			m_model.eyeBrows.Expresion_Brow_Drop_R__RL_21__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Brow_Drop_R__RL_21__"))].valor;
			m_model.eyeBrows.Expresion_Brow_Raise_Inner_L__RL_16__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Brow_Raise_Inner_L__RL_16__"))].valor;
			m_model.eyeBrows.Expresion_Brow_Raise_L__RL_22__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Brow_Raise_L__RL_22__"))].valor;
			m_model.eyeBrows.Expresion_Brow_Drop_L__RL_20__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Brow_Drop_L__RL_20__"))].valor;
			m_model.tongue.ExpresionTongue_Curl_U__RL_14__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("ExpresionTongue_Curl_U__RL_14__"))].valor;
			m_model.tongue.ExpresionTongue_Curl_D__RL_15__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("ExpresionTongue_Curl_D__RL_15__"))].valor;
			m_model.tongue.ExpresionTongue_up__RL_9__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("ExpresionTongue_up__RL_9__"))].valor;
			m_model.tongue.ExpresionTongue_Narrow__RL_12__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("ExpresionTongue_Narrow__RL_12__"))].valor;
			m_model.tongue.ExpresionTongue_Out__RL_11__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("ExpresionTongue_Out__RL_11__"))].valor;
			m_model.tongue.ExpresionTongue_Raise__RL_10__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("ExpresionTongue_Raise__RL_10__"))].valor;
			m_model.tongue.ExpresionTongue_Lower__RL_13__ = controller.diccResultados[controller.IndexDeKey(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("ExpresionTongue_Lower__RL_13__"))].valor;
			m_model.jaw.x = jawController.diccResultados[jawController.IndexDeKey(ControladorDeJawV2.Axis.x.ToString())].valor;
		}

		// Token: 0x14000021 RID: 33
		// (add) Token: 0x060001C4 RID: 452 RVA: 0x0000BB94 File Offset: 0x00009D94
		// (remove) Token: 0x060001C5 RID: 453 RVA: 0x0000BBCC File Offset: 0x00009DCC
		public event Action<IUIElementoConValor, IUIPanel> onModelChanged;

		// Token: 0x14000022 RID: 34
		// (add) Token: 0x060001C6 RID: 454 RVA: 0x0000BC04 File Offset: 0x00009E04
		// (remove) Token: 0x060001C7 RID: 455 RVA: 0x0000BC3C File Offset: 0x00009E3C
		public event Action accion1;

		// Token: 0x060001C8 RID: 456 RVA: 0x0000BC71 File Offset: 0x00009E71
		[ModelValueChangedListener(escucharTodosLosElementosAnteriores = true)]
		protected virtual void OnModelChanged(IUIElementoConValor elemento)
		{
			Action<IUIElementoConValor, IUIPanel> action = this.onModelChanged;
			if (action == null)
			{
				return;
			}
			action(elemento, elemento.transform.GetComponentInParent<IUIPanel>());
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x0000BC8F File Offset: 0x00009E8F
		[BotonDePanel]
		[Label("Ok", "US")]
		public void Accion1()
		{
			Action action = this.accion1;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x040000FE RID: 254
		[Modelo]
		[Label("EyeBrows", "US")]
		public GestosFacialesShapesEyeBrows eyeBrows = new GestosFacialesShapesEyeBrows();

		// Token: 0x040000FF RID: 255
		[Modelo]
		[Label("Eyes", "US")]
		public GestosFacialesShapesEyes eyes = new GestosFacialesShapesEyes();

		// Token: 0x04000100 RID: 256
		[Modelo]
		[Label("Nose", "US")]
		public GestosFacialesShapesNose nose = new GestosFacialesShapesNose();

		// Token: 0x04000101 RID: 257
		[Modelo]
		[Label("Cheeks And Chin", "US")]
		public GestosFacialesShapesCheeksAndChin cheeksAndChin = new GestosFacialesShapesCheeksAndChin();

		// Token: 0x04000102 RID: 258
		[Modelo]
		[Label("Mouth", "US")]
		public GestosFacialesShapesMouth mouth = new GestosFacialesShapesMouth();

		// Token: 0x04000103 RID: 259
		[Modelo]
		[Label("Lips", "US")]
		public GestosFacialesShapesLips lips = new GestosFacialesShapesLips();

		// Token: 0x04000104 RID: 260
		[Modelo]
		[Label("Jaw", "US")]
		public GestosFacialesShapesJaw jaw = new GestosFacialesShapesJaw();

		// Token: 0x04000105 RID: 261
		[Modelo]
		[Label("Tongue", "US")]
		public GestosFacialesShapesTongue tongue = new GestosFacialesShapesTongue();
	}
}
