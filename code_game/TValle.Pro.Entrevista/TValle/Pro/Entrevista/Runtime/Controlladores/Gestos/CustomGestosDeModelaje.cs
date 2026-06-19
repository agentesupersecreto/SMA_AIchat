using System;
using System.Collections.Generic;
using Assets.Base.Behaviours.Runtime.Characters;
using Assets._ReusableScripts;
using Assets._ReusableScripts.Controllers;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Chars.Controladores;
using Assets._ReusableScripts.CuchiCuchi.Controllers.Ojos.Parpadeos;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Controlladores.Gestos
{
	// Token: 0x0200010C RID: 268
	public class CustomGestosDeModelaje : AplicableBehaviour
	{
		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000910 RID: 2320 RVA: 0x000353BA File Offset: 0x000335BA
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x06000911 RID: 2321 RVA: 0x000353C4 File Offset: 0x000335C4
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.controller = this.GetComponentEnRoot(false);
			this.jawController = this.GetComponentEnRoot(false);
			this.genericCharacterPuedeHabla = this.GetComponentEnRoot(false);
			this.m_CharacterGestuable = this.GetComponentEnRoot(false);
			this.controlDeParpadeo = this.GetComponentEnRoot(false);
		}

		// Token: 0x06000912 RID: 2322 RVA: 0x00035418 File Offset: 0x00033618
		public override void OnUpdateEvent1()
		{
			if (this.modificables == null || this.modificables.Count == 0)
			{
				return;
			}
			bool flag = this.JawXMod.valor.valor > 3f;
			bool flag2 = this.ExpresionTongue_Curl_U__RL_14__Mod.valor.valor > 33f || this.ExpresionTongue_Curl_D__RL_15__Mod.valor.valor > 33f || this.ExpresionTongue_Out__RL_11__Mod.valor.valor > 33f || this.ExpresionTongue_Raise__RL_10__Mod.valor.valor > 33f || this.ExpresionTongue_Lower__RL_13__Mod.valor.valor > 33f;
			if (flag)
			{
				this.m_puedeHablarConClaridad.valor.valor = false;
				this.m_bocaAbierta.valor.valor = true;
				this.m_bocaSellada.valor.valor = false;
				return;
			}
			if (flag2)
			{
				this.m_puedeHablarConClaridad.valor.valor = false;
				this.m_bocaAbierta.valor.valor = false;
				this.m_bocaSellada.valor.valor = true;
				return;
			}
			this.m_puedeHablarConClaridad.valor.valor = false;
			this.m_bocaAbierta.valor.valor = false;
			this.m_bocaSellada.valor.valor = false;
		}

		// Token: 0x06000913 RID: 2323 RVA: 0x0003556C File Offset: 0x0003376C
		public void ChangeGesto(string field, float valor)
		{
			if (this.m_tongueFields.Contains(field))
			{
				float num = Mathf.InverseLerp(0f, 10f, this.JawXMod.valor.valor).InPow(2f);
				valor *= num;
			}
			ModificadorDeFloat modificadorDeFloat;
			if (this.modificables.TryGetValue(field, out modificadorDeFloat))
			{
				modificadorDeFloat.valor.valor = valor;
			}
		}

		// Token: 0x06000914 RID: 2324 RVA: 0x000355D4 File Offset: 0x000337D4
		public void StartGestos()
		{
			this.modificables.Clear();
			this.m_puedeHablarConClaridad = this.genericCharacterPuedeHabla.puedeHablarConClaridad.ObtenerModificadorNotNull(this);
			this.m_bocaAbierta = this.m_CharacterGestuable.bocaAbiertaOverrideOR.ObtenerModificadorNotNull(this);
			this.m_bocaSellada = this.m_CharacterGestuable.bocaSelladaOverrideOR.ObtenerModificadorNotNull(this);
			this.Expresion_Mouth_Open__RL_44__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Mouth_Open__RL_44__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Open__RL_1__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Open__RL_1__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Explosive__RL_2__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Explosive__RL_2__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Tight_O__RL_4__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Tight_O__RL_4__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Wide__RL_6__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Wide__RL_6__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Tight__RL_5__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Tight__RL_5__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Affricate__RL_7__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Affricate__RL_7__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.modificables.Add("Expresion_Mouth_Open__RL_44__", this.Expresion_Mouth_Open__RL_44__Mod);
			this.modificables.Add("Expresion_Open__RL_1__", this.Expresion_Open__RL_1__Mod);
			this.modificables.Add("Expresion_Explosive__RL_2__", this.Expresion_Explosive__RL_2__Mod);
			this.modificables.Add("Expresion_Tight_O__RL_4__", this.Expresion_Tight_O__RL_4__Mod);
			this.modificables.Add("Expresion_Wide__RL_6__", this.Expresion_Wide__RL_6__Mod);
			this.modificables.Add("Expresion_Tight__RL_5__", this.Expresion_Tight__RL_5__Mod);
			this.modificables.Add("Expresion_Affricate__RL_7__", this.Expresion_Affricate__RL_7__Mod);
			this.Expresion_Lips_Drop_L_Side__RL_36__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Lips_Drop_L_Side__RL_36__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Lips_Drop__RL_26__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Lips_Drop__RL_26__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Lip_Raise_Top__RL_45__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Lip_Raise_Top__RL_45__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Lip_Open__RL_8__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Lip_Open__RL_8__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Lips_Smirk_R__RL_33__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Lips_Smirk_R__RL_33__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Lips_Open__RL_51__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Lips_Open__RL_51__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Dental_Lip__RL_3__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Dental_Lip__RL_3__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Lips_Widen__RL_40__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Lips_Widen__RL_40__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Lips_Smirk_L__RL_32__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Lips_Smirk_L__RL_32__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Lips_Drop_Sides__RL_35__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Lips_Drop_Sides__RL_35__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Lips_Smirk__RL_31__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Lips_Smirk__RL_31__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Lips_Puckered_Open__RL_41__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Lips_Puckered_Open__RL_41__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Lips_Jut_Open__RL_39__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Lips_Jut_Open__RL_39__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Lips_Zipped_Tight__RL_43__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Lips_Zipped_Tight__RL_43__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Lips_Drop_R_Side__RL_37__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Lips_Drop_R_Side__RL_37__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Lips_Widen_Sides__RL_34__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Lips_Widen_Sides__RL_34__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Lips_Tuck__RL_46__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Lips_Tuck__RL_46__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.modificables.Add("Expresion_Lips_Drop_L_Side__RL_36__", this.Expresion_Lips_Drop_L_Side__RL_36__Mod);
			this.modificables.Add("Expresion_Lips_Drop__RL_26__", this.Expresion_Lips_Drop__RL_26__Mod);
			this.modificables.Add("Expresion_Lip_Raise_Top__RL_45__", this.Expresion_Lip_Raise_Top__RL_45__Mod);
			this.modificables.Add("Expresion_Lip_Open__RL_8__", this.Expresion_Lip_Open__RL_8__Mod);
			this.modificables.Add("Expresion_Lips_Smirk_R__RL_33__", this.Expresion_Lips_Smirk_R__RL_33__Mod);
			this.modificables.Add("Expresion_Lips_Open__RL_51__", this.Expresion_Lips_Open__RL_51__Mod);
			this.modificables.Add("Expresion_Dental_Lip__RL_3__", this.Expresion_Dental_Lip__RL_3__Mod);
			this.modificables.Add("Expresion_Lips_Widen__RL_40__", this.Expresion_Lips_Widen__RL_40__Mod);
			this.modificables.Add("Expresion_Lips_Smirk_L__RL_32__", this.Expresion_Lips_Smirk_L__RL_32__Mod);
			this.modificables.Add("Expresion_Lips_Drop_Sides__RL_35__", this.Expresion_Lips_Drop_Sides__RL_35__Mod);
			this.modificables.Add("Expresion_Lips_Smirk__RL_31__", this.Expresion_Lips_Smirk__RL_31__Mod);
			this.modificables.Add("Expresion_Lips_Puckered_Open__RL_41__", this.Expresion_Lips_Puckered_Open__RL_41__Mod);
			this.modificables.Add("Expresion_Lips_Jut_Open__RL_39__", this.Expresion_Lips_Jut_Open__RL_39__Mod);
			this.modificables.Add("Expresion_Lips_Zipped_Tight__RL_43__", this.Expresion_Lips_Zipped_Tight__RL_43__Mod);
			this.modificables.Add("Expresion_Lips_Drop_R_Side__RL_37__", this.Expresion_Lips_Drop_R_Side__RL_37__Mod);
			this.modificables.Add("Expresion_Lips_Widen_Sides__RL_34__", this.Expresion_Lips_Widen_Sides__RL_34__Mod);
			this.modificables.Add("Expresion_Lips_Tuck__RL_46__", this.Expresion_Lips_Tuck__RL_46__Mod);
			this.Expresion_Eye_Blink_L__RL_49__Mod = this.controlDeParpadeo.modificadoresDeValoresForzados.winkLSumable.ObtenerModificadorNotNull(this);
			this.Expresion_Eyes_Blink__RL_48__Mod = this.controlDeParpadeo.modificadoresDeValoresForzados.blinkSumable.ObtenerModificadorNotNull(this);
			this.Expresion_Eyelids_Enlarge__RL_42__Mod = this.controlDeParpadeo.modificadoresDeValoresForzados.enlargeSumable.ObtenerModificadorNotNull(this);
			this.Expresion_Eye_Blink_R__RL_50__Mod = this.controlDeParpadeo.modificadoresDeValoresForzados.winkRSumable.ObtenerModificadorNotNull(this);
			this.Expresion_Eyes_Squint__RL_47__Mod = this.controlDeParpadeo.modificadoresDeValoresForzados.squintSumable.ObtenerModificadorNotNull(this);
			this.modificables.Add("Expresion_Eye_Blink_L__RL_49__", this.Expresion_Eye_Blink_L__RL_49__Mod);
			this.modificables.Add("Expresion_Eyes_Blink__RL_48__", this.Expresion_Eyes_Blink__RL_48__Mod);
			this.modificables.Add("Expresion_Eyelids_Enlarge__RL_42__", this.Expresion_Eyelids_Enlarge__RL_42__Mod);
			this.modificables.Add("Expresion_Eye_Blink_R__RL_50__", this.Expresion_Eye_Blink_R__RL_50__Mod);
			this.modificables.Add("Expresion_Eyes_Squint__RL_47__", this.Expresion_Eyes_Squint__RL_47__Mod);
			this.Expresion_Nose_Flank_Raise__RL_30__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Nose_Flank_Raise__RL_30__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Nose_Flank_Raise_L__RL_28__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Nose_Flank_Raise_L__RL_28__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Nose_Scrunch__RL_27__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Nose_Scrunch__RL_27__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Nose_Flank_Raise_R__RL_29__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Nose_Flank_Raise_R__RL_29__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.modificables.Add("Expresion_Nose_Flank_Raise__RL_30__", this.Expresion_Nose_Flank_Raise__RL_30__Mod);
			this.modificables.Add("Expresion_Nose_Flank_Raise_L__RL_28__", this.Expresion_Nose_Flank_Raise_L__RL_28__Mod);
			this.modificables.Add("Expresion_Nose_Scrunch__RL_27__", this.Expresion_Nose_Scrunch__RL_27__Mod);
			this.modificables.Add("Expresion_Nose_Flank_Raise_R__RL_29__", this.Expresion_Nose_Flank_Raise_R__RL_29__Mod);
			this.Expresion_Cheek_Raise_L__RL_24__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Cheek_Raise_L__RL_24__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Cheek_Raise_R__RL_25__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Cheek_Raise_R__RL_25__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Chin_Raise__RL_38__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Chin_Raise__RL_38__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.modificables.Add("Expresion_Cheek_Raise_L__RL_24__", this.Expresion_Cheek_Raise_L__RL_24__Mod);
			this.modificables.Add("Expresion_Cheek_Raise_R__RL_25__", this.Expresion_Cheek_Raise_R__RL_25__Mod);
			this.modificables.Add("Expresion_Chin_Raise__RL_38__", this.Expresion_Chin_Raise__RL_38__Mod);
			this.Expresion_Jaw_Move_D__RL_61__ExprecionMod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Jaw_Move_D__RL_61__Exprecion"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Jaw_Rotate_D__RL_58__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Jaw_Rotate_D__RL_58__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.JawXMod = this.jawController.ObtenerOrdenesDeID(0, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.modificables.Add("Expresion_Jaw_Move_D__RL_61__Exprecion", this.Expresion_Jaw_Move_D__RL_61__ExprecionMod);
			this.modificables.Add("Expresion_Jaw_Rotate_D__RL_58__", this.Expresion_Jaw_Rotate_D__RL_58__Mod);
			this.modificables.Add("x", this.JawXMod);
			this.Expresion_Brow_Raise_R__RL_23__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Brow_Raise_R__RL_23__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Brow_Raise_Outer_L__RL_18__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Brow_Raise_Outer_L__RL_18__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Brow_Raise_Inner_R__RL_17__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Brow_Raise_Inner_R__RL_17__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Brow_Raise_Outer_R__RL_19__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Brow_Raise_Outer_R__RL_19__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Brow_Drop_R__RL_21__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Brow_Drop_R__RL_21__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Brow_Raise_Inner_L__RL_16__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Brow_Raise_Inner_L__RL_16__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Brow_Raise_L__RL_22__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Brow_Raise_L__RL_22__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.Expresion_Brow_Drop_L__RL_20__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("Expresion_Brow_Drop_L__RL_20__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.modificables.Add("Expresion_Brow_Raise_R__RL_23__", this.Expresion_Brow_Raise_R__RL_23__Mod);
			this.modificables.Add("Expresion_Brow_Raise_Outer_L__RL_18__", this.Expresion_Brow_Raise_Outer_L__RL_18__Mod);
			this.modificables.Add("Expresion_Brow_Raise_Inner_R__RL_17__", this.Expresion_Brow_Raise_Inner_R__RL_17__Mod);
			this.modificables.Add("Expresion_Brow_Raise_Outer_R__RL_19__", this.Expresion_Brow_Raise_Outer_R__RL_19__Mod);
			this.modificables.Add("Expresion_Brow_Drop_R__RL_21__", this.Expresion_Brow_Drop_R__RL_21__Mod);
			this.modificables.Add("Expresion_Brow_Raise_Inner_L__RL_16__", this.Expresion_Brow_Raise_Inner_L__RL_16__Mod);
			this.modificables.Add("Expresion_Brow_Raise_L__RL_22__", this.Expresion_Brow_Raise_L__RL_22__Mod);
			this.modificables.Add("Expresion_Brow_Drop_L__RL_20__", this.Expresion_Brow_Drop_L__RL_20__Mod);
			this.ExpresionTongue_Curl_U__RL_14__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("ExpresionTongue_Curl_U__RL_14__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.ExpresionTongue_Curl_D__RL_15__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("ExpresionTongue_Curl_D__RL_15__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.ExpresionTongue_up__RL_9__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("ExpresionTongue_up__RL_9__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.ExpresionTongue_Narrow__RL_12__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("ExpresionTongue_Narrow__RL_12__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.ExpresionTongue_Out__RL_11__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("ExpresionTongue_Out__RL_11__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.ExpresionTongue_Raise__RL_10__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("ExpresionTongue_Raise__RL_10__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.ExpresionTongue_Lower__RL_13__Mod = this.controller.ObtenerOrdenesDeID(MapaSingleton<MapaDeCCAnimationBlendShapes>.instance.ObtenerValorDeField("ExpresionTongue_Lower__RL_13__"), ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.modificables.Add("ExpresionTongue_Curl_U__RL_14__", this.ExpresionTongue_Curl_U__RL_14__Mod);
			this.modificables.Add("ExpresionTongue_Curl_D__RL_15__", this.ExpresionTongue_Curl_D__RL_15__Mod);
			this.modificables.Add("ExpresionTongue_up__RL_9__", this.ExpresionTongue_up__RL_9__Mod);
			this.modificables.Add("ExpresionTongue_Narrow__RL_12__", this.ExpresionTongue_Narrow__RL_12__Mod);
			this.modificables.Add("ExpresionTongue_Out__RL_11__", this.ExpresionTongue_Out__RL_11__Mod);
			this.modificables.Add("ExpresionTongue_Raise__RL_10__", this.ExpresionTongue_Raise__RL_10__Mod);
			this.modificables.Add("ExpresionTongue_Lower__RL_13__", this.ExpresionTongue_Lower__RL_13__Mod);
			this.m_tongueFields.Add("ExpresionTongue_Curl_U__RL_14__");
			this.m_tongueFields.Add("ExpresionTongue_Curl_D__RL_15__");
			this.m_tongueFields.Add("ExpresionTongue_up__RL_9__");
			this.m_tongueFields.Add("ExpresionTongue_Narrow__RL_12__");
			this.m_tongueFields.Add("ExpresionTongue_Out__RL_11__");
			this.m_tongueFields.Add("ExpresionTongue_Raise__RL_10__");
			this.m_tongueFields.Add("ExpresionTongue_Lower__RL_13__");
		}

		// Token: 0x06000915 RID: 2325 RVA: 0x00036438 File Offset: 0x00034638
		public void EndGestos()
		{
			this.modificables.Clear();
			this.m_tongueFields.Clear();
			ModificadorDeBool puedeHablarConClaridad = this.m_puedeHablarConClaridad;
			if (puedeHablarConClaridad != null)
			{
				puedeHablarConClaridad.TryRemoverDeOwner(true);
			}
			this.m_puedeHablarConClaridad = null;
			ModificadorDeBool bocaAbierta = this.m_bocaAbierta;
			if (bocaAbierta != null)
			{
				bocaAbierta.TryRemoverDeOwner(true);
			}
			this.m_bocaAbierta = null;
			ModificadorDeBool bocaSellada = this.m_bocaSellada;
			if (bocaSellada != null)
			{
				bocaSellada.TryRemoverDeOwner(true);
			}
			this.m_bocaSellada = null;
			ModificadorDeFloat expresion_Mouth_Open__RL_44__Mod = this.Expresion_Mouth_Open__RL_44__Mod;
			if (expresion_Mouth_Open__RL_44__Mod != null)
			{
				expresion_Mouth_Open__RL_44__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Open__RL_1__Mod = this.Expresion_Open__RL_1__Mod;
			if (expresion_Open__RL_1__Mod != null)
			{
				expresion_Open__RL_1__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Explosive__RL_2__Mod = this.Expresion_Explosive__RL_2__Mod;
			if (expresion_Explosive__RL_2__Mod != null)
			{
				expresion_Explosive__RL_2__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Tight_O__RL_4__Mod = this.Expresion_Tight_O__RL_4__Mod;
			if (expresion_Tight_O__RL_4__Mod != null)
			{
				expresion_Tight_O__RL_4__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Wide__RL_6__Mod = this.Expresion_Wide__RL_6__Mod;
			if (expresion_Wide__RL_6__Mod != null)
			{
				expresion_Wide__RL_6__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Tight__RL_5__Mod = this.Expresion_Tight__RL_5__Mod;
			if (expresion_Tight__RL_5__Mod != null)
			{
				expresion_Tight__RL_5__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Affricate__RL_7__Mod = this.Expresion_Affricate__RL_7__Mod;
			if (expresion_Affricate__RL_7__Mod != null)
			{
				expresion_Affricate__RL_7__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Lips_Drop_L_Side__RL_36__Mod = this.Expresion_Lips_Drop_L_Side__RL_36__Mod;
			if (expresion_Lips_Drop_L_Side__RL_36__Mod != null)
			{
				expresion_Lips_Drop_L_Side__RL_36__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Lips_Drop__RL_26__Mod = this.Expresion_Lips_Drop__RL_26__Mod;
			if (expresion_Lips_Drop__RL_26__Mod != null)
			{
				expresion_Lips_Drop__RL_26__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Lip_Raise_Top__RL_45__Mod = this.Expresion_Lip_Raise_Top__RL_45__Mod;
			if (expresion_Lip_Raise_Top__RL_45__Mod != null)
			{
				expresion_Lip_Raise_Top__RL_45__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Lip_Open__RL_8__Mod = this.Expresion_Lip_Open__RL_8__Mod;
			if (expresion_Lip_Open__RL_8__Mod != null)
			{
				expresion_Lip_Open__RL_8__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Lips_Smirk_R__RL_33__Mod = this.Expresion_Lips_Smirk_R__RL_33__Mod;
			if (expresion_Lips_Smirk_R__RL_33__Mod != null)
			{
				expresion_Lips_Smirk_R__RL_33__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Lips_Open__RL_51__Mod = this.Expresion_Lips_Open__RL_51__Mod;
			if (expresion_Lips_Open__RL_51__Mod != null)
			{
				expresion_Lips_Open__RL_51__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Dental_Lip__RL_3__Mod = this.Expresion_Dental_Lip__RL_3__Mod;
			if (expresion_Dental_Lip__RL_3__Mod != null)
			{
				expresion_Dental_Lip__RL_3__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Lips_Widen__RL_40__Mod = this.Expresion_Lips_Widen__RL_40__Mod;
			if (expresion_Lips_Widen__RL_40__Mod != null)
			{
				expresion_Lips_Widen__RL_40__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Lips_Smirk_L__RL_32__Mod = this.Expresion_Lips_Smirk_L__RL_32__Mod;
			if (expresion_Lips_Smirk_L__RL_32__Mod != null)
			{
				expresion_Lips_Smirk_L__RL_32__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Lips_Drop_Sides__RL_35__Mod = this.Expresion_Lips_Drop_Sides__RL_35__Mod;
			if (expresion_Lips_Drop_Sides__RL_35__Mod != null)
			{
				expresion_Lips_Drop_Sides__RL_35__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Lips_Smirk__RL_31__Mod = this.Expresion_Lips_Smirk__RL_31__Mod;
			if (expresion_Lips_Smirk__RL_31__Mod != null)
			{
				expresion_Lips_Smirk__RL_31__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Lips_Puckered_Open__RL_41__Mod = this.Expresion_Lips_Puckered_Open__RL_41__Mod;
			if (expresion_Lips_Puckered_Open__RL_41__Mod != null)
			{
				expresion_Lips_Puckered_Open__RL_41__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Lips_Jut_Open__RL_39__Mod = this.Expresion_Lips_Jut_Open__RL_39__Mod;
			if (expresion_Lips_Jut_Open__RL_39__Mod != null)
			{
				expresion_Lips_Jut_Open__RL_39__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Lips_Zipped_Tight__RL_43__Mod = this.Expresion_Lips_Zipped_Tight__RL_43__Mod;
			if (expresion_Lips_Zipped_Tight__RL_43__Mod != null)
			{
				expresion_Lips_Zipped_Tight__RL_43__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Lips_Drop_R_Side__RL_37__Mod = this.Expresion_Lips_Drop_R_Side__RL_37__Mod;
			if (expresion_Lips_Drop_R_Side__RL_37__Mod != null)
			{
				expresion_Lips_Drop_R_Side__RL_37__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Lips_Widen_Sides__RL_34__Mod = this.Expresion_Lips_Widen_Sides__RL_34__Mod;
			if (expresion_Lips_Widen_Sides__RL_34__Mod != null)
			{
				expresion_Lips_Widen_Sides__RL_34__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Lips_Tuck__RL_46__Mod = this.Expresion_Lips_Tuck__RL_46__Mod;
			if (expresion_Lips_Tuck__RL_46__Mod != null)
			{
				expresion_Lips_Tuck__RL_46__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Eye_Blink_L__RL_49__Mod = this.Expresion_Eye_Blink_L__RL_49__Mod;
			if (expresion_Eye_Blink_L__RL_49__Mod != null)
			{
				expresion_Eye_Blink_L__RL_49__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Eyes_Blink__RL_48__Mod = this.Expresion_Eyes_Blink__RL_48__Mod;
			if (expresion_Eyes_Blink__RL_48__Mod != null)
			{
				expresion_Eyes_Blink__RL_48__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Eyelids_Enlarge__RL_42__Mod = this.Expresion_Eyelids_Enlarge__RL_42__Mod;
			if (expresion_Eyelids_Enlarge__RL_42__Mod != null)
			{
				expresion_Eyelids_Enlarge__RL_42__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Eye_Blink_R__RL_50__Mod = this.Expresion_Eye_Blink_R__RL_50__Mod;
			if (expresion_Eye_Blink_R__RL_50__Mod != null)
			{
				expresion_Eye_Blink_R__RL_50__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Eyes_Squint__RL_47__Mod = this.Expresion_Eyes_Squint__RL_47__Mod;
			if (expresion_Eyes_Squint__RL_47__Mod != null)
			{
				expresion_Eyes_Squint__RL_47__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Nose_Flank_Raise__RL_30__Mod = this.Expresion_Nose_Flank_Raise__RL_30__Mod;
			if (expresion_Nose_Flank_Raise__RL_30__Mod != null)
			{
				expresion_Nose_Flank_Raise__RL_30__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Nose_Flank_Raise_L__RL_28__Mod = this.Expresion_Nose_Flank_Raise_L__RL_28__Mod;
			if (expresion_Nose_Flank_Raise_L__RL_28__Mod != null)
			{
				expresion_Nose_Flank_Raise_L__RL_28__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Nose_Scrunch__RL_27__Mod = this.Expresion_Nose_Scrunch__RL_27__Mod;
			if (expresion_Nose_Scrunch__RL_27__Mod != null)
			{
				expresion_Nose_Scrunch__RL_27__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Nose_Flank_Raise_R__RL_29__Mod = this.Expresion_Nose_Flank_Raise_R__RL_29__Mod;
			if (expresion_Nose_Flank_Raise_R__RL_29__Mod != null)
			{
				expresion_Nose_Flank_Raise_R__RL_29__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Cheek_Raise_L__RL_24__Mod = this.Expresion_Cheek_Raise_L__RL_24__Mod;
			if (expresion_Cheek_Raise_L__RL_24__Mod != null)
			{
				expresion_Cheek_Raise_L__RL_24__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Cheek_Raise_R__RL_25__Mod = this.Expresion_Cheek_Raise_R__RL_25__Mod;
			if (expresion_Cheek_Raise_R__RL_25__Mod != null)
			{
				expresion_Cheek_Raise_R__RL_25__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Chin_Raise__RL_38__Mod = this.Expresion_Chin_Raise__RL_38__Mod;
			if (expresion_Chin_Raise__RL_38__Mod != null)
			{
				expresion_Chin_Raise__RL_38__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Jaw_Move_D__RL_61__ExprecionMod = this.Expresion_Jaw_Move_D__RL_61__ExprecionMod;
			if (expresion_Jaw_Move_D__RL_61__ExprecionMod != null)
			{
				expresion_Jaw_Move_D__RL_61__ExprecionMod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Jaw_Rotate_D__RL_58__Mod = this.Expresion_Jaw_Rotate_D__RL_58__Mod;
			if (expresion_Jaw_Rotate_D__RL_58__Mod != null)
			{
				expresion_Jaw_Rotate_D__RL_58__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat jawXMod = this.JawXMod;
			if (jawXMod != null)
			{
				jawXMod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Brow_Raise_R__RL_23__Mod = this.Expresion_Brow_Raise_R__RL_23__Mod;
			if (expresion_Brow_Raise_R__RL_23__Mod != null)
			{
				expresion_Brow_Raise_R__RL_23__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Brow_Raise_Outer_L__RL_18__Mod = this.Expresion_Brow_Raise_Outer_L__RL_18__Mod;
			if (expresion_Brow_Raise_Outer_L__RL_18__Mod != null)
			{
				expresion_Brow_Raise_Outer_L__RL_18__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Brow_Raise_Inner_R__RL_17__Mod = this.Expresion_Brow_Raise_Inner_R__RL_17__Mod;
			if (expresion_Brow_Raise_Inner_R__RL_17__Mod != null)
			{
				expresion_Brow_Raise_Inner_R__RL_17__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Brow_Raise_Outer_R__RL_19__Mod = this.Expresion_Brow_Raise_Outer_R__RL_19__Mod;
			if (expresion_Brow_Raise_Outer_R__RL_19__Mod != null)
			{
				expresion_Brow_Raise_Outer_R__RL_19__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Brow_Drop_R__RL_21__Mod = this.Expresion_Brow_Drop_R__RL_21__Mod;
			if (expresion_Brow_Drop_R__RL_21__Mod != null)
			{
				expresion_Brow_Drop_R__RL_21__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Brow_Raise_Inner_L__RL_16__Mod = this.Expresion_Brow_Raise_Inner_L__RL_16__Mod;
			if (expresion_Brow_Raise_Inner_L__RL_16__Mod != null)
			{
				expresion_Brow_Raise_Inner_L__RL_16__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Brow_Raise_L__RL_22__Mod = this.Expresion_Brow_Raise_L__RL_22__Mod;
			if (expresion_Brow_Raise_L__RL_22__Mod != null)
			{
				expresion_Brow_Raise_L__RL_22__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresion_Brow_Drop_L__RL_20__Mod = this.Expresion_Brow_Drop_L__RL_20__Mod;
			if (expresion_Brow_Drop_L__RL_20__Mod != null)
			{
				expresion_Brow_Drop_L__RL_20__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresionTongue_Curl_U__RL_14__Mod = this.ExpresionTongue_Curl_U__RL_14__Mod;
			if (expresionTongue_Curl_U__RL_14__Mod != null)
			{
				expresionTongue_Curl_U__RL_14__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresionTongue_Curl_D__RL_15__Mod = this.ExpresionTongue_Curl_D__RL_15__Mod;
			if (expresionTongue_Curl_D__RL_15__Mod != null)
			{
				expresionTongue_Curl_D__RL_15__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresionTongue_up__RL_9__Mod = this.ExpresionTongue_up__RL_9__Mod;
			if (expresionTongue_up__RL_9__Mod != null)
			{
				expresionTongue_up__RL_9__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresionTongue_Narrow__RL_12__Mod = this.ExpresionTongue_Narrow__RL_12__Mod;
			if (expresionTongue_Narrow__RL_12__Mod != null)
			{
				expresionTongue_Narrow__RL_12__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresionTongue_Out__RL_11__Mod = this.ExpresionTongue_Out__RL_11__Mod;
			if (expresionTongue_Out__RL_11__Mod != null)
			{
				expresionTongue_Out__RL_11__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresionTongue_Raise__RL_10__Mod = this.ExpresionTongue_Raise__RL_10__Mod;
			if (expresionTongue_Raise__RL_10__Mod != null)
			{
				expresionTongue_Raise__RL_10__Mod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat expresionTongue_Lower__RL_13__Mod = this.ExpresionTongue_Lower__RL_13__Mod;
			if (expresionTongue_Lower__RL_13__Mod == null)
			{
				return;
			}
			expresionTongue_Lower__RL_13__Mod.TryRemoverDeOwner(true);
		}

		// Token: 0x040004D1 RID: 1233
		private Dictionary<string, ModificadorDeFloat> modificables = new Dictionary<string, ModificadorDeFloat>();

		// Token: 0x040004D2 RID: 1234
		private HashSet<string> m_tongueFields = new HashSet<string>();

		// Token: 0x040004D3 RID: 1235
		private ControladorDeCCAnimationBlendShapes controller;

		// Token: 0x040004D4 RID: 1236
		private ControladorDeJawV2 jawController;

		// Token: 0x040004D5 RID: 1237
		private ICharacterGestuable m_CharacterGestuable;

		// Token: 0x040004D6 RID: 1238
		private GenericCharacterPuedeHablar genericCharacterPuedeHabla;

		// Token: 0x040004D7 RID: 1239
		private ControlDeParpadeo controlDeParpadeo;

		// Token: 0x040004D8 RID: 1240
		[SerializeField]
		private ModificadorDeBool m_puedeHablarConClaridad;

		// Token: 0x040004D9 RID: 1241
		[SerializeField]
		private ModificadorDeBool m_bocaAbierta;

		// Token: 0x040004DA RID: 1242
		[SerializeField]
		private ModificadorDeBool m_bocaSellada;

		// Token: 0x040004DB RID: 1243
		public ModificadorDeFloat Expresion_Mouth_Open__RL_44__Mod;

		// Token: 0x040004DC RID: 1244
		public ModificadorDeFloat Expresion_Open__RL_1__Mod;

		// Token: 0x040004DD RID: 1245
		public ModificadorDeFloat Expresion_Explosive__RL_2__Mod;

		// Token: 0x040004DE RID: 1246
		public ModificadorDeFloat Expresion_Tight_O__RL_4__Mod;

		// Token: 0x040004DF RID: 1247
		public ModificadorDeFloat Expresion_Wide__RL_6__Mod;

		// Token: 0x040004E0 RID: 1248
		public ModificadorDeFloat Expresion_Tight__RL_5__Mod;

		// Token: 0x040004E1 RID: 1249
		public ModificadorDeFloat Expresion_Affricate__RL_7__Mod;

		// Token: 0x040004E2 RID: 1250
		public ModificadorDeFloat Expresion_Lips_Drop_L_Side__RL_36__Mod;

		// Token: 0x040004E3 RID: 1251
		public ModificadorDeFloat Expresion_Lips_Drop__RL_26__Mod;

		// Token: 0x040004E4 RID: 1252
		public ModificadorDeFloat Expresion_Lip_Raise_Top__RL_45__Mod;

		// Token: 0x040004E5 RID: 1253
		public ModificadorDeFloat Expresion_Lip_Open__RL_8__Mod;

		// Token: 0x040004E6 RID: 1254
		public ModificadorDeFloat Expresion_Lips_Smirk_R__RL_33__Mod;

		// Token: 0x040004E7 RID: 1255
		public ModificadorDeFloat Expresion_Lips_Open__RL_51__Mod;

		// Token: 0x040004E8 RID: 1256
		public ModificadorDeFloat Expresion_Dental_Lip__RL_3__Mod;

		// Token: 0x040004E9 RID: 1257
		public ModificadorDeFloat Expresion_Lips_Widen__RL_40__Mod;

		// Token: 0x040004EA RID: 1258
		public ModificadorDeFloat Expresion_Lips_Smirk_L__RL_32__Mod;

		// Token: 0x040004EB RID: 1259
		public ModificadorDeFloat Expresion_Lips_Drop_Sides__RL_35__Mod;

		// Token: 0x040004EC RID: 1260
		public ModificadorDeFloat Expresion_Lips_Smirk__RL_31__Mod;

		// Token: 0x040004ED RID: 1261
		public ModificadorDeFloat Expresion_Lips_Puckered_Open__RL_41__Mod;

		// Token: 0x040004EE RID: 1262
		public ModificadorDeFloat Expresion_Lips_Jut_Open__RL_39__Mod;

		// Token: 0x040004EF RID: 1263
		public ModificadorDeFloat Expresion_Lips_Zipped_Tight__RL_43__Mod;

		// Token: 0x040004F0 RID: 1264
		public ModificadorDeFloat Expresion_Lips_Drop_R_Side__RL_37__Mod;

		// Token: 0x040004F1 RID: 1265
		public ModificadorDeFloat Expresion_Lips_Widen_Sides__RL_34__Mod;

		// Token: 0x040004F2 RID: 1266
		public ModificadorDeFloat Expresion_Lips_Tuck__RL_46__Mod;

		// Token: 0x040004F3 RID: 1267
		public ModificadorDeFloat Expresion_Eye_Blink_L__RL_49__Mod;

		// Token: 0x040004F4 RID: 1268
		public ModificadorDeFloat Expresion_Eyes_Blink__RL_48__Mod;

		// Token: 0x040004F5 RID: 1269
		public ModificadorDeFloat Expresion_Eyelids_Enlarge__RL_42__Mod;

		// Token: 0x040004F6 RID: 1270
		public ModificadorDeFloat Expresion_Eye_Blink_R__RL_50__Mod;

		// Token: 0x040004F7 RID: 1271
		public ModificadorDeFloat Expresion_Eyes_Squint__RL_47__Mod;

		// Token: 0x040004F8 RID: 1272
		public ModificadorDeFloat Expresion_Nose_Flank_Raise__RL_30__Mod;

		// Token: 0x040004F9 RID: 1273
		public ModificadorDeFloat Expresion_Nose_Flank_Raise_L__RL_28__Mod;

		// Token: 0x040004FA RID: 1274
		public ModificadorDeFloat Expresion_Nose_Scrunch__RL_27__Mod;

		// Token: 0x040004FB RID: 1275
		public ModificadorDeFloat Expresion_Nose_Flank_Raise_R__RL_29__Mod;

		// Token: 0x040004FC RID: 1276
		public ModificadorDeFloat Expresion_Cheek_Raise_L__RL_24__Mod;

		// Token: 0x040004FD RID: 1277
		public ModificadorDeFloat Expresion_Cheek_Raise_R__RL_25__Mod;

		// Token: 0x040004FE RID: 1278
		public ModificadorDeFloat Expresion_Chin_Raise__RL_38__Mod;

		// Token: 0x040004FF RID: 1279
		public ModificadorDeFloat Expresion_Jaw_Move_D__RL_61__ExprecionMod;

		// Token: 0x04000500 RID: 1280
		public ModificadorDeFloat Expresion_Jaw_Rotate_D__RL_58__Mod;

		// Token: 0x04000501 RID: 1281
		public ModificadorDeFloat JawXMod;

		// Token: 0x04000502 RID: 1282
		public ModificadorDeFloat Expresion_Brow_Raise_R__RL_23__Mod;

		// Token: 0x04000503 RID: 1283
		public ModificadorDeFloat Expresion_Brow_Raise_Outer_L__RL_18__Mod;

		// Token: 0x04000504 RID: 1284
		public ModificadorDeFloat Expresion_Brow_Raise_Inner_R__RL_17__Mod;

		// Token: 0x04000505 RID: 1285
		public ModificadorDeFloat Expresion_Brow_Raise_Outer_R__RL_19__Mod;

		// Token: 0x04000506 RID: 1286
		public ModificadorDeFloat Expresion_Brow_Drop_R__RL_21__Mod;

		// Token: 0x04000507 RID: 1287
		public ModificadorDeFloat Expresion_Brow_Raise_Inner_L__RL_16__Mod;

		// Token: 0x04000508 RID: 1288
		public ModificadorDeFloat Expresion_Brow_Raise_L__RL_22__Mod;

		// Token: 0x04000509 RID: 1289
		public ModificadorDeFloat Expresion_Brow_Drop_L__RL_20__Mod;

		// Token: 0x0400050A RID: 1290
		public ModificadorDeFloat ExpresionTongue_Curl_U__RL_14__Mod;

		// Token: 0x0400050B RID: 1291
		public ModificadorDeFloat ExpresionTongue_Curl_D__RL_15__Mod;

		// Token: 0x0400050C RID: 1292
		public ModificadorDeFloat ExpresionTongue_up__RL_9__Mod;

		// Token: 0x0400050D RID: 1293
		public ModificadorDeFloat ExpresionTongue_Narrow__RL_12__Mod;

		// Token: 0x0400050E RID: 1294
		public ModificadorDeFloat ExpresionTongue_Out__RL_11__Mod;

		// Token: 0x0400050F RID: 1295
		public ModificadorDeFloat ExpresionTongue_Raise__RL_10__Mod;

		// Token: 0x04000510 RID: 1296
		public ModificadorDeFloat ExpresionTongue_Lower__RL_13__Mod;
	}
}
