using System;
using Assets._ReusableScripts.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Skins.ArmaduresSkins;
using Assets._ReusableScripts.CuchiCuchi._CharactersBasics;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers.Ojos.Parpadeos
{
	// Token: 0x0200024E RID: 590
	public class ControlDeParpadeo : CustomUpdatedMonobehaviourBase, IControlDeParpadeo
	{
		// Token: 0x170002EB RID: 747
		// (get) Token: 0x06000D2D RID: 3373 RVA: 0x0003C91C File Offset: 0x0003AB1C
		public ControlDeParpadeoValores valoresEnviadosAControlladorDeSkin
		{
			get
			{
				return this.m_ValoresEnviadosASkin;
			}
		}

		// Token: 0x170002EC RID: 748
		// (get) Token: 0x06000D2E RID: 3374 RVA: 0x0003C924 File Offset: 0x0003AB24
		// (set) Token: 0x06000D2F RID: 3375 RVA: 0x0003C92C File Offset: 0x0003AB2C
		ControlDeParpadeoValores IControlDeParpadeo.targets
		{
			get
			{
				return this.m_valoresPermanentes;
			}
			set
			{
				this.m_valoresPermanentes = value;
			}
		}

		// Token: 0x170002ED RID: 749
		// (get) Token: 0x06000D30 RID: 3376 RVA: 0x0003C935 File Offset: 0x0003AB35
		ControlDeParpadeoValores IControlDeParpadeo.currents
		{
			get
			{
				return this.m_ValoresPermanentesLast;
			}
		}

		// Token: 0x170002EE RID: 750
		// (get) Token: 0x06000D31 RID: 3377 RVA: 0x0003C93D File Offset: 0x0003AB3D
		ControlDeParpadeoModificablesHolder IControlDeParpadeo.modificableDeParpadeo
		{
			get
			{
				return this.modificableDeParpadeo;
			}
		}

		// Token: 0x170002EF RID: 751
		// (get) Token: 0x06000D32 RID: 3378 RVA: 0x0003C945 File Offset: 0x0003AB45
		ControlDeParpadeoModificablesHolder IControlDeParpadeo.modificableDeGuiñoR
		{
			get
			{
				return this.modificableDeGuiñoR;
			}
		}

		// Token: 0x170002F0 RID: 752
		// (get) Token: 0x06000D33 RID: 3379 RVA: 0x0003C94D File Offset: 0x0003AB4D
		ControlDeParpadeoModificablesHolder IControlDeParpadeo.modificableDeGuiñoL
		{
			get
			{
				return this.modificableDeGuiñoL;
			}
		}

		// Token: 0x170002F1 RID: 753
		// (get) Token: 0x06000D34 RID: 3380 RVA: 0x0003C955 File Offset: 0x0003AB55
		ControlDeParpadeoModificablesHolder IControlDeParpadeo.modificableDeAchiquitamiento
		{
			get
			{
				return this.modificableDeAchiquitamiento;
			}
		}

		// Token: 0x170002F2 RID: 754
		// (get) Token: 0x06000D35 RID: 3381 RVA: 0x0003C95D File Offset: 0x0003AB5D
		ControlDeParpadeoModificablesHolder IControlDeParpadeo.modificableDeAgrandamiento
		{
			get
			{
				return this.modificableDeAgrandamiento;
			}
		}

		// Token: 0x170002F3 RID: 755
		// (get) Token: 0x06000D36 RID: 3382 RVA: 0x0003C965 File Offset: 0x0003AB65
		public float cerradoWeightL
		{
			get
			{
				return this.m_currentCerraduraDeOjoLMod;
			}
		}

		// Token: 0x170002F4 RID: 756
		// (get) Token: 0x06000D37 RID: 3383 RVA: 0x0003C96D File Offset: 0x0003AB6D
		public float cerradoWeightR
		{
			get
			{
				return this.m_currentCerraduraDeOjoRMod;
			}
		}

		// Token: 0x06000D38 RID: 3384 RVA: 0x0003C978 File Offset: 0x0003AB78
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_controllador = this.GetComponentEnRoot(false);
			if (this.m_controllador == null)
			{
				throw new ArgumentNullException("m_controllador", "m_controllador null reference.");
			}
			this.m_controllador.stared += this.OnControllerStared;
			this.defaultModsGenerales.Init(this.modificableGeneral, this);
			this.nextModsDeParpadeo.Init(this.modificableDeParpadeo, this);
			this.nextModsDeAchiquitamiento.Init(this.modificableDeAchiquitamiento, this);
			this.nextModsDeAgrandamiento.Init(this.modificableDeAgrandamiento, this);
			this.nextModsDeGuiñoR.Init(this.modificableDeGuiñoR, this);
			this.nextModsDeGuiñoL.Init(this.modificableDeGuiñoL, this);
			this.m_parpadeoEventosHolder.comienza = new Action(this.OnParpadeoComienza);
			this.m_parpadeoEventosHolder.medio = new Action(this.OnParpadeoMedio);
			this.m_parpadeoEventosHolder.termina = new Action(this.OnParpadeoTermina);
			this.m_guiñarREventosHolder.comienza = new Action(this.OnGuiñoRComienza);
			this.m_guiñarREventosHolder.medio = new Action(this.OnGuiñoRMedio);
			this.m_guiñarREventosHolder.termina = new Action(this.OnGuiñoRTermina);
			this.m_guiñarLEventosHolder.comienza = new Action(this.OnGuiñoLComienza);
			this.m_guiñarLEventosHolder.medio = new Action(this.OnGuiñoLMedio);
			this.m_guiñarLEventosHolder.termina = new Action(this.OnGuiñoLTermina);
			this.m_agrandamientoEventosHolder.comienza = new Action(this.OnAgrandamientoComienza);
			this.m_agrandamientoEventosHolder.medio = new Action(this.OnAgrandamientoMedio);
			this.m_agrandamientoEventosHolder.termina = new Action(this.OnAgrandamientoTermina);
			this.m_achiquitamientoEventosHolder.comienza = new Action(this.OnAchiquitamientoComienza);
			this.m_achiquitamientoEventosHolder.medio = new Action(this.OnAchiquitamientoMedio);
			this.m_achiquitamientoEventosHolder.termina = new Action(this.OnAchiquitamientoTermina);
		}

		// Token: 0x06000D39 RID: 3385 RVA: 0x0003CB8C File Offset: 0x0003AD8C
		protected sealed override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_forceValuesLast = default(ControlDeParpadeoValores);
			this.m_ValoresPermanentesLast = default(ControlDeParpadeoValores);
		}

		// Token: 0x06000D3A RID: 3386 RVA: 0x0003CBB0 File Offset: 0x0003ADB0
		private void OnControllerStared(object obj)
		{
			ArmatureSkinsClasificada componentEnCharacter = this.GetComponentEnCharacter(false);
			if (componentEnCharacter == null)
			{
				throw new ArgumentNullException("m_skins", "m_skins null reference.");
			}
			this.m_body = componentEnCharacter.skinPartes.body.skinnedMeshRenderer;
			if (this.m_body == null)
			{
				throw new ArgumentNullException("m_body", "m_body null reference.");
			}
			Mesh sharedMesh = this.m_body.sharedMesh;
			MapaDeFemaleBlendShapes instance = MapaSingleton<MapaDeFemaleBlendShapes>.instance;
			MapaDeCCAnimationBlendShapes instance2 = MapaSingleton<MapaDeCCAnimationBlendShapes>.instance;
			this.m_Index.blinkL = this.m_controllador.IndexDeKey(instance2.Expresion_Eye_Blink_L__RL_49__);
			if (this.m_Index.blinkL < 0)
			{
				throw new InvalidOperationException();
			}
			this.m_Index.blinkR = this.m_controllador.IndexDeKey(instance2.Expresion_Eye_Blink_R__RL_50__);
			if (this.m_Index.blinkR < 0)
			{
				throw new InvalidOperationException();
			}
			this.m_Index.blinkLR = this.m_controllador.IndexDeKey(instance2.Expresion_Eyes_Blink__RL_48__);
			if (this.m_Index.blinkLR < 0)
			{
				throw new InvalidOperationException();
			}
			this.m_Index.enlarge = this.m_controllador.IndexDeKey(instance2.Expresion_Eyelids_Enlarge__RL_42__);
			if (this.m_Index.enlarge < 0)
			{
				throw new InvalidOperationException();
			}
			this.m_Index.squint = this.m_controllador.IndexDeKey(instance2.Expresion_Eyes_Squint__RL_47__);
			if (this.m_Index.squint < 0)
			{
				throw new InvalidOperationException();
			}
			this.m_IndexNoControladosAnimados.cheekRaiseL = this.m_controllador.IndexDeKey(instance2.Expresion_Cheek_Raise_L__RL_24__);
			this.m_IndexNoControladosAnimados.cheekRaiseR = this.m_controllador.IndexDeKey(instance2.Expresion_Cheek_Raise_R__RL_25__);
			if (this.m_IndexNoControladosAnimados.cheekRaiseL < 0)
			{
				throw new InvalidOperationException();
			}
			if (this.m_IndexNoControladosAnimados.cheekRaiseR < 0)
			{
				throw new InvalidOperationException();
			}
			this.m_IndexNoControladosNoAnimados.eyesRound = sharedMesh.GetBlendShapeIndex(instance.FACE_Eye_Round);
			this.m_IndexNoControladosNoAnimados.eyesThin = sharedMesh.GetBlendShapeIndex(instance.FACE_Eye_Thin);
			this.m_IndexNoControladosNoAnimados.eyesTopFlat = sharedMesh.GetBlendShapeIndex(instance.FACE_Eyelid_Top_Flat);
			this.m_IndexNoControladosNoAnimados.topInMin = sharedMesh.GetBlendShapeIndex(instance.FACE_Eyelid_Top_In_Height_n);
			this.m_IndexNoControladosNoAnimados.topInMax = sharedMesh.GetBlendShapeIndex(instance.FACE_Eyelid_Top_In_Height_p);
			this.m_IndexNoControladosNoAnimados.bottomOutMax = sharedMesh.GetBlendShapeIndex(instance.FACE_Eyelid_Bottom_Out_Height_p);
			this.m_IndexNoControladosNoAnimados.bottomOutMin = sharedMesh.GetBlendShapeIndex(instance.FACE_Eyelid_Bottom_Out_Height_n);
			if (this.m_IndexNoControladosNoAnimados.eyesRound < 0)
			{
				throw new InvalidOperationException();
			}
			if (this.m_IndexNoControladosNoAnimados.eyesThin < 0)
			{
				throw new InvalidOperationException();
			}
			if (this.m_IndexNoControladosNoAnimados.eyesTopFlat < 0)
			{
				throw new InvalidOperationException();
			}
			if (this.m_IndexNoControladosNoAnimados.topInMin < 0)
			{
				throw new InvalidOperationException();
			}
			if (this.m_IndexNoControladosNoAnimados.topInMax < 0)
			{
				throw new InvalidOperationException();
			}
			if (this.m_IndexNoControladosNoAnimados.bottomOutMax < 0)
			{
				throw new InvalidOperationException();
			}
			if (this.m_IndexNoControladosNoAnimados.bottomOutMin < 0)
			{
				throw new InvalidOperationException();
			}
			this.m_modificadores.blinkL = this.m_controllador.ObtenerOrdenesDeID(this.m_Index.blinkL, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.m_modificadores.blinkR = this.m_controllador.ObtenerOrdenesDeID(this.m_Index.blinkR, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.m_modificadores.blinkLR = this.m_controllador.ObtenerOrdenesDeID(this.m_Index.blinkLR, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.m_modificadores.enlarge = this.m_controllador.ObtenerOrdenesDeID(this.m_Index.enlarge, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.m_modificadores.squint = this.m_controllador.ObtenerOrdenesDeID(this.m_Index.squint, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto).modificable.ObtenerModificadorNotNull(this);
			this.m_controllador.updating += this.M_controllador_updating;
		}

		// Token: 0x06000D3B RID: 3387 RVA: 0x0003CF9F File Offset: 0x0003B19F
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_controllador != null)
			{
				this.m_controllador.updating -= this.M_controllador_updating;
			}
		}

		// Token: 0x06000D3C RID: 3388 RVA: 0x0003CFC7 File Offset: 0x0003B1C7
		private void M_controllador_updating(ControllerMultipleDirectoModificableDeUnSoloFloat obj)
		{
			this.DoUpdate();
		}

		// Token: 0x06000D3D RID: 3389 RVA: 0x0003CFCF File Offset: 0x0003B1CF
		public void Parpadear(float velocidadMod)
		{
			this.nextModsDeParpadeo.SetVelocidadMod(velocidadMod);
			this.parpadearFlag = true;
		}

		// Token: 0x06000D3E RID: 3390 RVA: 0x0003CFE4 File Offset: 0x0003B1E4
		public void GuiñarR(float velocidadMod)
		{
			this.nextModsDeGuiñoR.SetVelocidadMod(velocidadMod);
			this.guiñarRFlag = true;
		}

		// Token: 0x06000D3F RID: 3391 RVA: 0x0003CFF9 File Offset: 0x0003B1F9
		public void GuiñarL(float velocidadMod)
		{
			this.nextModsDeGuiñoL.SetVelocidadMod(velocidadMod);
			this.guiñarLFlag = true;
		}

		// Token: 0x06000D40 RID: 3392 RVA: 0x0003D00E File Offset: 0x0003B20E
		public void Achiquitar(float velocidadMod)
		{
			this.nextModsDeAchiquitamiento.SetVelocidadMod(velocidadMod);
			this.achiquitarFlag = true;
		}

		// Token: 0x06000D41 RID: 3393 RVA: 0x0003D023 File Offset: 0x0003B223
		public void Agrandar(float velocidadMod)
		{
			this.nextModsDeAgrandamiento.SetVelocidadMod(velocidadMod);
			this.agrandarFlag = true;
		}

		// Token: 0x06000D42 RID: 3394 RVA: 0x0003D038 File Offset: 0x0003B238
		private void DoUpdate()
		{
			if (this.m_controllador == null)
			{
				return;
			}
			this.SetValues(ref this.m_ValoresDespuesDeAnimacion);
			this.SetValues(ref this.m_ValoresNoControladosDespuesDeAnimacion);
			this.UpdateParpadeo();
			this.UpdateGuiñoR();
			this.UpdateGuiñoL();
			this.UpdateAchiquitamiento();
			this.UpdateAgrandamiento();
			this.m_ValoresEnviadosASkin = this.m_ValoresDespuesDeAnimacion;
			this.ForzarValoresSmooth(ref this.m_forceValuesLast, ref this.m_ValoresEnviadosASkin, this.forceValues, this.modificadoresDeValoresForzados);
			this.ForzarValores(ref this.m_ValoresEnviadosASkin, this.m_ValoresDeCambio);
			this.ForzarValoresSmooth(ref this.m_ValoresPermanentesLast, this.m_valoresPermanentes, null);
			this.m_ValoresEnviadosASkin.AddValoresClamp(this.m_ValoresPermanentesLast);
			float num = 1f;
			num *= this.BlinkModSegunSquint(ref this.m_ValoresEnviadosASkin);
			num *= this.BlinkModSegunEyeThin(ref this.m_ValoresEnviadosASkin);
			num *= this.BlinkModSegunEyeTopFlat(ref this.m_ValoresEnviadosASkin);
			num *= this.BlinkModSegunEyeTopInMax(ref this.m_ValoresEnviadosASkin);
			num *= this.BlinkModSegunBottomOutMax(ref this.m_ValoresEnviadosASkin);
			float num2 = num;
			float num3 = num;
			float num5;
			float num6;
			float num7;
			float num8;
			float num4 = this.BlinkModSegunCheekRaise(ref this.m_ValoresEnviadosASkin, out num5, out num6, out num7, out num8);
			num2 *= num8;
			num3 *= num7;
			num *= num4;
			float num9 = Mathf.Clamp01(MathfExtension.InverseLerpUnclamped(0f, 100f, this.m_ValoresEnviadosASkin.blink));
			float num10 = Mathf.Clamp01(MathfExtension.InverseLerpUnclamped(0f, 100f, this.m_ValoresEnviadosASkin.winkR));
			float num11 = Mathf.Clamp01(MathfExtension.InverseLerpUnclamped(0f, 100f, this.m_ValoresEnviadosASkin.winkL));
			this.m_ValoresEnviadosASkin.blink = this.m_ValoresEnviadosASkin.blink * num;
			this.m_ValoresEnviadosASkin.winkL = this.m_ValoresEnviadosASkin.winkL * num3 * (1f - num9);
			this.m_ValoresEnviadosASkin.winkR = this.m_ValoresEnviadosASkin.winkR * num2 * (1f - num9);
			this.m_ValoresEnviadosASkin.winkL = this.m_ValoresEnviadosASkin.winkL + num6 * num9;
			this.m_ValoresEnviadosASkin.winkR = this.m_ValoresEnviadosASkin.winkR + num5 * num9;
			this.BlinkExtraSegunEnlarge(ref this.m_ValoresEnviadosASkin, num9, num11, num10);
			this.BlinkExtraSegunEyesRound(ref this.m_ValoresEnviadosASkin, num9, num11, num10);
			this.BlinkExtraSegunTopInMin(ref this.m_ValoresEnviadosASkin, num9, num11, num10);
			this.BlinkExtraSegunBottomOutMin(ref this.m_ValoresEnviadosASkin, num9, num11, num10);
			this.m_modificadores.blinkL.valor.valor = this.m_ValoresEnviadosASkin.winkL;
			this.m_modificadores.blinkR.valor.valor = this.m_ValoresEnviadosASkin.winkR;
			this.m_modificadores.blinkLR.valor.valor = this.m_ValoresEnviadosASkin.blink;
			this.m_modificadores.enlarge.valor.valor = this.m_ValoresEnviadosASkin.enlarge;
			this.m_modificadores.squint.valor.valor = this.m_ValoresEnviadosASkin.squint;
			this.m_currentCerraduraDeOjoLMod = MathfExtension.InverseLerpUnclamped(0f, 100f, this.m_ValoresEnviadosASkin.winkL);
			this.m_currentCerraduraDeOjoRMod = MathfExtension.InverseLerpUnclamped(0f, 100f, this.m_ValoresEnviadosASkin.winkR);
			float num12 = MathfExtension.InverseLerpUnclamped(0f, 100f, this.m_ValoresEnviadosASkin.blink);
			this.m_currentCerraduraDeOjoLMod += num12;
			this.m_currentCerraduraDeOjoRMod += num12;
		}

		// Token: 0x06000D43 RID: 3395 RVA: 0x0003D3A4 File Offset: 0x0003B5A4
		private void UpdateCambio(ref bool flag, ref float cambioTarget, ref float resultado, float modificadorMinimoDeVelocidad, float power, float tiempoIn, float tiempoOut, Action startCallback = null, Action middleCallback = null, Action endCallback = null)
		{
			try
			{
				bool flag2 = false;
				if (flag)
				{
					cambioTarget = 100f;
					if (startCallback != null)
					{
						startCallback();
					}
				}
				else if (resultado >= 100f)
				{
					resultado = 100f;
					if (middleCallback != null)
					{
						middleCallback();
					}
					cambioTarget = 0f;
				}
				else if (resultado > 0f)
				{
					flag2 = true;
				}
				this.MoveTowards(ref resultado, cambioTarget, modificadorMinimoDeVelocidad, power, tiempoIn, tiempoOut);
				if (flag2 && resultado <= 0f && endCallback != null)
				{
					endCallback();
				}
			}
			finally
			{
				flag = false;
			}
		}

		// Token: 0x06000D44 RID: 3396 RVA: 0x0003D438 File Offset: 0x0003B638
		private void UpdateGuiñoR()
		{
			float power = this.config.guiño.power;
			float tiempoIn = this.config.guiño.tiempoIn;
			float tiempoOut = this.config.guiño.tiempoOut;
			this.modificableDeGuiñoR.Modificar(ref power, ref tiempoIn, ref tiempoOut);
			this.UpdateCambio(ref this.guiñarRFlag, ref this.m_BlinkR, ref this.m_ValoresDeCambio.winkR, this.config.guiño.modificadorMinimo, power, tiempoIn, tiempoOut, this.m_guiñarREventosHolder.comienza, this.m_guiñarREventosHolder.medio, this.m_guiñarREventosHolder.termina);
		}

		// Token: 0x06000D45 RID: 3397 RVA: 0x0003D4DC File Offset: 0x0003B6DC
		private void UpdateGuiñoL()
		{
			float power = this.config.guiño.power;
			float tiempoIn = this.config.guiño.tiempoIn;
			float tiempoOut = this.config.guiño.tiempoOut;
			this.modificableDeGuiñoL.Modificar(ref power, ref tiempoIn, ref tiempoOut);
			this.UpdateCambio(ref this.guiñarLFlag, ref this.m_BlinkL, ref this.m_ValoresDeCambio.winkL, this.config.guiño.modificadorMinimo, power, tiempoIn, tiempoOut, this.m_guiñarLEventosHolder.comienza, this.m_guiñarLEventosHolder.medio, this.m_guiñarLEventosHolder.termina);
		}

		// Token: 0x06000D46 RID: 3398 RVA: 0x0003D580 File Offset: 0x0003B780
		private void UpdateParpadeo()
		{
			float power = this.config.parpadeo.power;
			float tiempoIn = this.config.parpadeo.tiempoIn;
			float tiempoOut = this.config.parpadeo.tiempoOut;
			this.modificableDeParpadeo.Modificar(ref power, ref tiempoIn, ref tiempoOut);
			this.UpdateCambio(ref this.parpadearFlag, ref this.m_BlinkTarget, ref this.m_ValoresDeCambio.blink, this.config.parpadeo.modificadorMinimo, power, tiempoIn, tiempoOut, this.m_parpadeoEventosHolder.comienza, this.m_parpadeoEventosHolder.medio, this.m_parpadeoEventosHolder.termina);
		}

		// Token: 0x06000D47 RID: 3399 RVA: 0x0003D624 File Offset: 0x0003B824
		private void UpdateAchiquitamiento()
		{
			float power = this.config.achiquitamiento.power;
			float tiempoIn = this.config.achiquitamiento.tiempoIn;
			float tiempoOut = this.config.achiquitamiento.tiempoOut;
			this.modificableDeAchiquitamiento.Modificar(ref power, ref tiempoIn, ref tiempoOut);
			this.UpdateCambio(ref this.achiquitarFlag, ref this.m_SquintTarget, ref this.m_ValoresDeCambio.squint, this.config.achiquitamiento.modificadorMinimo, power, tiempoIn, tiempoOut, this.m_achiquitamientoEventosHolder.comienza, this.m_achiquitamientoEventosHolder.medio, this.m_achiquitamientoEventosHolder.termina);
		}

		// Token: 0x06000D48 RID: 3400 RVA: 0x0003D6C8 File Offset: 0x0003B8C8
		private void UpdateAgrandamiento()
		{
			float power = this.config.agrandamiento.power;
			float tiempoIn = this.config.agrandamiento.tiempoIn;
			float tiempoOut = this.config.agrandamiento.tiempoOut;
			this.modificableDeAgrandamiento.Modificar(ref power, ref tiempoIn, ref tiempoOut);
			this.UpdateCambio(ref this.agrandarFlag, ref this.m_Enlarge, ref this.m_ValoresDeCambio.enlarge, this.config.agrandamiento.modificadorMinimo, power, tiempoIn, tiempoOut, this.m_agrandamientoEventosHolder.comienza, this.m_agrandamientoEventosHolder.medio, this.m_agrandamientoEventosHolder.termina);
		}

		// Token: 0x06000D49 RID: 3401 RVA: 0x00003B39 File Offset: 0x00001D39
		protected void OnParpadeoComienza()
		{
		}

		// Token: 0x06000D4A RID: 3402 RVA: 0x00003B39 File Offset: 0x00001D39
		protected void OnParpadeoMedio()
		{
		}

		// Token: 0x06000D4B RID: 3403 RVA: 0x0003D76A File Offset: 0x0003B96A
		protected void OnParpadeoTermina()
		{
			this.nextModsDeParpadeo.Reset();
		}

		// Token: 0x06000D4C RID: 3404 RVA: 0x00003B39 File Offset: 0x00001D39
		protected void OnGuiñoRComienza()
		{
		}

		// Token: 0x06000D4D RID: 3405 RVA: 0x00003B39 File Offset: 0x00001D39
		protected void OnGuiñoRMedio()
		{
		}

		// Token: 0x06000D4E RID: 3406 RVA: 0x0003D777 File Offset: 0x0003B977
		protected void OnGuiñoRTermina()
		{
			this.nextModsDeGuiñoR.Reset();
		}

		// Token: 0x06000D4F RID: 3407 RVA: 0x00003B39 File Offset: 0x00001D39
		protected void OnGuiñoLComienza()
		{
		}

		// Token: 0x06000D50 RID: 3408 RVA: 0x00003B39 File Offset: 0x00001D39
		protected void OnGuiñoLMedio()
		{
		}

		// Token: 0x06000D51 RID: 3409 RVA: 0x0003D784 File Offset: 0x0003B984
		protected void OnGuiñoLTermina()
		{
			this.nextModsDeGuiñoL.Reset();
		}

		// Token: 0x06000D52 RID: 3410 RVA: 0x00003B39 File Offset: 0x00001D39
		protected void OnAchiquitamientoComienza()
		{
		}

		// Token: 0x06000D53 RID: 3411 RVA: 0x00003B39 File Offset: 0x00001D39
		protected void OnAchiquitamientoMedio()
		{
		}

		// Token: 0x06000D54 RID: 3412 RVA: 0x0003D791 File Offset: 0x0003B991
		protected void OnAchiquitamientoTermina()
		{
			this.nextModsDeAchiquitamiento.Reset();
		}

		// Token: 0x06000D55 RID: 3413 RVA: 0x00003B39 File Offset: 0x00001D39
		protected void OnAgrandamientoComienza()
		{
		}

		// Token: 0x06000D56 RID: 3414 RVA: 0x00003B39 File Offset: 0x00001D39
		protected void OnAgrandamientoMedio()
		{
		}

		// Token: 0x06000D57 RID: 3415 RVA: 0x0003D79E File Offset: 0x0003B99E
		protected void OnAgrandamientoTermina()
		{
			this.nextModsDeAgrandamiento.Reset();
		}

		// Token: 0x06000D58 RID: 3416 RVA: 0x0003D7AC File Offset: 0x0003B9AC
		private void MoveTowards(ref float result, float target, float modificadorMinimoDeVelocidad, float power, float tiempoIn, float tiempoOut)
		{
			this.modificableGeneral.Modificar(ref power, ref tiempoIn, ref tiempoOut);
			float num = Mathf.InverseLerp(100f, 0f, result);
			num = Mathf.Lerp(modificadorMinimoDeVelocidad, 1f, num);
			num = num.OutPow(power);
			target = Mathf.Clamp(target, 0f, 100f);
			float num2;
			if (result > target)
			{
				num2 = tiempoOut;
			}
			else if (result < target)
			{
				num2 = tiempoIn;
			}
			else
			{
				num2 = (tiempoIn + tiempoOut) / 2f;
			}
			result = Mathf.MoveTowards(result, target, 100f / num2 * Time.deltaTime * num);
		}

		// Token: 0x06000D59 RID: 3417 RVA: 0x0003D840 File Offset: 0x0003BA40
		private void BlinkExtraSegunEyesRound(ref ControlDeParpadeoValores valores, float blinkMod, float winkLMod, float winkRMod)
		{
			if (this.m_ValoresNoControladosDespuesDeAnimacion.eyesRound > 0f)
			{
				float num = Mathf.LerpUnclamped(0f, this.config.blinkExtraNecesarioSiEyeRoundMax, this.m_ValoresNoControladosDespuesDeAnimacion.eyesRound / 100f);
				valores.blink += num * blinkMod;
				valores.winkL += num * winkLMod;
				valores.winkR += num * winkRMod;
			}
		}

		// Token: 0x06000D5A RID: 3418 RVA: 0x0003D8B0 File Offset: 0x0003BAB0
		private void BlinkExtraSegunTopInMin(ref ControlDeParpadeoValores valores, float blinkMod, float winkLMod, float winkRMod)
		{
			if (this.m_ValoresNoControladosDespuesDeAnimacion.topInMin > 0f)
			{
				float num = Mathf.LerpUnclamped(0f, this.config.blinkExtraNecesarioSiTopInMin, this.m_ValoresNoControladosDespuesDeAnimacion.topInMin / 100f);
				valores.blink += num * blinkMod;
				valores.winkL += num * winkLMod;
				valores.winkR += num * winkRMod;
			}
		}

		// Token: 0x06000D5B RID: 3419 RVA: 0x0003D920 File Offset: 0x0003BB20
		private void BlinkExtraSegunBottomOutMin(ref ControlDeParpadeoValores valores, float blinkMod, float winkLMod, float winkRMod)
		{
			if (this.m_ValoresNoControladosDespuesDeAnimacion.bottomOutMin > 0f)
			{
				float num = Mathf.LerpUnclamped(0f, this.config.blinkExtraNecesarioSiBottomOutMin, this.m_ValoresNoControladosDespuesDeAnimacion.bottomOutMin / 100f);
				valores.blink += num * blinkMod;
				valores.winkL += num * winkLMod;
				valores.winkR += num * winkRMod;
			}
		}

		// Token: 0x06000D5C RID: 3420 RVA: 0x0003D990 File Offset: 0x0003BB90
		private void BlinkExtraSegunEnlarge(ref ControlDeParpadeoValores valores, float blinkMod, float winkLMod, float winkRMod)
		{
			if (valores.enlarge > 0f)
			{
				float num = Mathf.LerpUnclamped(0f, this.config.blinkExtraNecesarioSiEnlargeMax, valores.enlarge / 100f);
				valores.blink += num * blinkMod;
				valores.winkL += num * winkLMod;
				valores.winkR += num * winkRMod;
			}
		}

		// Token: 0x06000D5D RID: 3421 RVA: 0x0003D9F4 File Offset: 0x0003BBF4
		private float BlinkModSegunSquint(ref ControlDeParpadeoValores valores)
		{
			if (valores.squint > 0f)
			{
				return Mathf.LerpUnclamped(100f, this.config.maxBlinkSiSquintMax, valores.squint / 100f) / 100f;
			}
			return 1f;
		}

		// Token: 0x06000D5E RID: 3422 RVA: 0x0003DA30 File Offset: 0x0003BC30
		private float BlinkModSegunCheekRaise(ref ControlDeParpadeoValores valores, out float winkR_AddingOnMaxBlink, out float winkL_AddingOnMaxBlink, out float winkRMod, out float winkLMod)
		{
			winkR_AddingOnMaxBlink = 0f;
			winkL_AddingOnMaxBlink = 0f;
			winkRMod = 1f;
			winkLMod = 1f;
			float num = this.m_ValoresNoControladosDespuesDeAnimacion.cheekRaiseL;
			float num2 = this.m_ValoresNoControladosDespuesDeAnimacion.cheekRaiseR;
			float num3 = Mathf.Min(num, num2);
			if (num3 <= 0f)
			{
				return 1f;
			}
			num -= num3;
			num2 -= num3;
			if (Mathf.Approximately(num, 0f))
			{
				num = 0f;
			}
			if (Mathf.Approximately(num2, 0f))
			{
				num2 = 0f;
			}
			float num4 = Mathf.LerpUnclamped(100f, this.config.maxBlinkSiCheekRaiseMax, num3 / 100f);
			winkRMod = num4 / 100f;
			winkLMod = num4 / 100f;
			if (num > 0f)
			{
				float num5 = Mathf.LerpUnclamped(100f, this.config.maxBlinkSiCheekRaiseMax, num / 100f);
				num4 = 100f - (100f - num5 + (100f - num4));
				winkR_AddingOnMaxBlink = 100f - num5;
				winkR_AddingOnMaxBlink = ((winkR_AddingOnMaxBlink < 0f) ? 0f : winkR_AddingOnMaxBlink);
				winkRMod = num4 / 100f;
			}
			if (num2 > 0f)
			{
				float num6 = Mathf.LerpUnclamped(100f, this.config.maxBlinkSiCheekRaiseMax, num2 / 100f);
				num4 = 100f - (100f - num6 + (100f - num4));
				winkL_AddingOnMaxBlink = 100f - num6;
				winkL_AddingOnMaxBlink = ((winkL_AddingOnMaxBlink < 0f) ? 0f : winkL_AddingOnMaxBlink);
				winkLMod = num4 / 100f;
			}
			return num4 / 100f;
		}

		// Token: 0x06000D5F RID: 3423 RVA: 0x0003DBBC File Offset: 0x0003BDBC
		private float BlinkModSegunEyeThin(ref ControlDeParpadeoValores valores)
		{
			if (this.m_ValoresNoControladosDespuesDeAnimacion.eyesThin > 0f)
			{
				return Mathf.LerpUnclamped(100f, this.config.maxBlinkSiEyeThinMax, this.m_ValoresNoControladosDespuesDeAnimacion.eyesThin / 100f) / 100f;
			}
			return 1f;
		}

		// Token: 0x06000D60 RID: 3424 RVA: 0x0003DC10 File Offset: 0x0003BE10
		private float BlinkModSegunEyeTopFlat(ref ControlDeParpadeoValores valores)
		{
			if (this.m_ValoresNoControladosDespuesDeAnimacion.eyesTopFlat > 0f)
			{
				return Mathf.LerpUnclamped(100f, this.config.maxBlinkSiEyeTopFlatMax, this.m_ValoresNoControladosDespuesDeAnimacion.eyesTopFlat / 100f) / 100f;
			}
			return 1f;
		}

		// Token: 0x06000D61 RID: 3425 RVA: 0x0003DC64 File Offset: 0x0003BE64
		private float BlinkModSegunEyeTopInMax(ref ControlDeParpadeoValores valores)
		{
			if (this.m_ValoresNoControladosDespuesDeAnimacion.topInMax > 0f)
			{
				return Mathf.LerpUnclamped(100f, this.config.maxBlinkSiTopInMax, this.m_ValoresNoControladosDespuesDeAnimacion.topInMax / 100f) / 100f;
			}
			return 1f;
		}

		// Token: 0x06000D62 RID: 3426 RVA: 0x0003DCB8 File Offset: 0x0003BEB8
		private float BlinkModSegunBottomOutMax(ref ControlDeParpadeoValores valores)
		{
			if (this.m_ValoresNoControladosDespuesDeAnimacion.bottomOutMax > 0f)
			{
				return Mathf.LerpUnclamped(100f, this.config.maxBlinkSiBottomOutMax, this.m_ValoresNoControladosDespuesDeAnimacion.bottomOutMax / 100f) / 100f;
			}
			return 1f;
		}

		// Token: 0x06000D63 RID: 3427 RVA: 0x0003DD0C File Offset: 0x0003BF0C
		[Obsolete("", true)]
		private void RedireccionarBlink_LR_A_R_L(ref ControlDeParpadeoValores valores)
		{
			if (valores.blink > 0f)
			{
				valores.winkR += valores.blink;
				valores.winkL += valores.blink;
				valores.winkR = Mathf.Clamp(valores.winkR, 0f, 100f);
				valores.winkL = Mathf.Clamp(valores.winkL, 0f, 100f);
				valores.blink = 0f;
			}
		}

		// Token: 0x06000D64 RID: 3428 RVA: 0x0003DD88 File Offset: 0x0003BF88
		private void SetValues(ref ControlDeParpadeoValores valores)
		{
			valores.blink = this.m_controllador.ObtenerValorActual(this.m_Index.blinkLR).valor;
			valores.winkL = this.m_controllador.ObtenerValorActual(this.m_Index.blinkL).valor;
			valores.winkR = this.m_controllador.ObtenerValorActual(this.m_Index.blinkR).valor;
			valores.enlarge = this.m_controllador.ObtenerValorActual(this.m_Index.enlarge).valor;
			valores.squint = this.m_controllador.ObtenerValorActual(this.m_Index.squint).valor;
		}

		// Token: 0x06000D65 RID: 3429 RVA: 0x0003DE3C File Offset: 0x0003C03C
		private void SetValues(ref ControlDeParpadeo.ValoresNoControlados valores)
		{
			valores.cheekRaiseL = this.m_controllador.ObtenerValorActual(this.m_IndexNoControladosAnimados.cheekRaiseL).valor;
			valores.cheekRaiseR = this.m_controllador.ObtenerValorActual(this.m_IndexNoControladosAnimados.cheekRaiseR).valor;
			valores.eyesRound = this.m_body.GetBlendShapeWeight(this.m_IndexNoControladosNoAnimados.eyesRound);
			valores.eyesThin = this.m_body.GetBlendShapeWeight(this.m_IndexNoControladosNoAnimados.eyesThin);
			valores.eyesTopFlat = this.m_body.GetBlendShapeWeight(this.m_IndexNoControladosNoAnimados.eyesTopFlat);
			valores.topInMin = this.m_body.GetBlendShapeWeight(this.m_IndexNoControladosNoAnimados.topInMin);
			valores.topInMax = this.m_body.GetBlendShapeWeight(this.m_IndexNoControladosNoAnimados.topInMax);
			valores.bottomOutMax = this.m_body.GetBlendShapeWeight(this.m_IndexNoControladosNoAnimados.bottomOutMax);
			valores.bottomOutMin = this.m_body.GetBlendShapeWeight(this.m_IndexNoControladosNoAnimados.bottomOutMin);
		}

		// Token: 0x06000D66 RID: 3430 RVA: 0x0003DF50 File Offset: 0x0003C150
		private void ForzarValores(ref ControlDeParpadeoValores valores, ControlDeParpadeoValores forzados)
		{
			valores.blink += forzados.blink;
			valores.winkL += forzados.winkL;
			valores.winkR += forzados.winkR;
			valores.enlarge += forzados.enlarge;
			valores.squint += forzados.squint;
		}

		// Token: 0x06000D67 RID: 3431 RVA: 0x0003DFBC File Offset: 0x0003C1BC
		private void ForzarValoresSmooth(ref ControlDeParpadeoValores last, ref ControlDeParpadeoValores targets, ControlDeParpadeoValores forzados, ControlDeParpadeo.ModificablesDeValores mods = null)
		{
			if (mods != null)
			{
				forzados = mods.Modificar(forzados);
			}
			float power = this.config.generales.parpadeo.power;
			float tiempoIn = this.config.generales.parpadeo.tiempoIn;
			float tiempoOut = this.config.generales.parpadeo.tiempoOut;
			this.modificableDeParpadeo.Modificar(ref power, ref tiempoIn, ref tiempoOut);
			this.MoveTowards(ref last.blink, forzados.blink + targets.blink, this.config.generales.parpadeo.modificadorMinimo, power, tiempoIn, tiempoOut);
			float power2 = this.config.generales.guiño.power;
			float tiempoIn2 = this.config.generales.guiño.tiempoIn;
			float tiempoOut2 = this.config.generales.guiño.tiempoOut;
			this.modificableDeGuiñoL.Modificar(ref power2, ref tiempoIn2, ref tiempoOut2);
			this.MoveTowards(ref last.winkL, forzados.winkL + targets.winkL, this.config.generales.guiño.modificadorMinimo, power2, tiempoIn2, tiempoOut2);
			float power3 = this.config.generales.guiño.power;
			float tiempoIn3 = this.config.generales.guiño.tiempoIn;
			float tiempoOut3 = this.config.generales.guiño.tiempoOut;
			this.modificableDeGuiñoR.Modificar(ref power3, ref tiempoIn3, ref tiempoOut3);
			this.MoveTowards(ref last.winkR, forzados.winkR + targets.winkR, this.config.generales.guiño.modificadorMinimo, power3, tiempoIn3, tiempoOut3);
			float power4 = this.config.generales.achiquitamiento.power;
			float tiempoIn4 = this.config.generales.achiquitamiento.tiempoIn;
			float tiempoOut4 = this.config.generales.achiquitamiento.tiempoOut;
			this.modificableDeAchiquitamiento.Modificar(ref power4, ref tiempoIn4, ref tiempoOut4);
			this.MoveTowards(ref last.squint, forzados.squint + targets.squint, this.config.generales.achiquitamiento.modificadorMinimo, power4, tiempoIn4, tiempoOut4);
			float power5 = this.config.generales.agrandamiento.power;
			float tiempoIn5 = this.config.generales.agrandamiento.tiempoIn;
			float tiempoOut5 = this.config.generales.agrandamiento.tiempoOut;
			this.modificableDeAgrandamiento.Modificar(ref power5, ref tiempoIn5, ref tiempoOut5);
			this.MoveTowards(ref last.enlarge, forzados.enlarge + targets.enlarge, this.config.generales.agrandamiento.modificadorMinimo, power5, tiempoIn5, tiempoOut5);
			targets.blink = last.blink;
			targets.winkL = last.winkL;
			targets.winkR = last.winkR;
			targets.enlarge = last.enlarge;
			targets.squint = last.squint;
		}

		// Token: 0x06000D68 RID: 3432 RVA: 0x0003E2C0 File Offset: 0x0003C4C0
		private void ForzarValoresSmooth(ref ControlDeParpadeoValores last, ControlDeParpadeoValores forzados, ControlDeParpadeo.ModificablesDeValores mods = null)
		{
			if (mods != null)
			{
				forzados = mods.Modificar(forzados);
			}
			float power = this.config.generales.parpadeo.power;
			float tiempoIn = this.config.generales.parpadeo.tiempoIn;
			float tiempoOut = this.config.generales.parpadeo.tiempoOut;
			this.modificableDeParpadeo.Modificar(ref power, ref tiempoIn, ref tiempoOut);
			this.MoveTowards(ref last.blink, forzados.blink, this.config.generales.parpadeo.modificadorMinimo, power, tiempoIn, tiempoOut);
			float power2 = this.config.generales.guiño.power;
			float tiempoIn2 = this.config.generales.guiño.tiempoIn;
			float tiempoOut2 = this.config.generales.guiño.tiempoOut;
			this.modificableDeGuiñoL.Modificar(ref power2, ref tiempoIn2, ref tiempoOut2);
			this.MoveTowards(ref last.winkL, forzados.winkL, this.config.generales.guiño.modificadorMinimo, power2, tiempoIn2, tiempoOut2);
			float power3 = this.config.generales.guiño.power;
			float tiempoIn3 = this.config.generales.guiño.tiempoIn;
			float tiempoOut3 = this.config.generales.guiño.tiempoOut;
			this.modificableDeGuiñoR.Modificar(ref power3, ref tiempoIn3, ref tiempoOut3);
			this.MoveTowards(ref last.winkR, forzados.winkR, this.config.generales.guiño.modificadorMinimo, power3, tiempoIn3, tiempoOut3);
			float power4 = this.config.generales.achiquitamiento.power;
			float tiempoIn4 = this.config.generales.achiquitamiento.tiempoIn;
			float tiempoOut4 = this.config.generales.achiquitamiento.tiempoOut;
			this.modificableDeAchiquitamiento.Modificar(ref power4, ref tiempoIn4, ref tiempoOut4);
			this.MoveTowards(ref last.squint, forzados.squint, this.config.generales.achiquitamiento.modificadorMinimo, power4, tiempoIn4, tiempoOut4);
			float power5 = this.config.generales.agrandamiento.power;
			float tiempoIn5 = this.config.generales.agrandamiento.tiempoIn;
			float tiempoOut5 = this.config.generales.agrandamiento.tiempoOut;
			this.modificableDeAgrandamiento.Modificar(ref power5, ref tiempoIn5, ref tiempoOut5);
			this.MoveTowards(ref last.enlarge, forzados.enlarge, this.config.generales.agrandamiento.modificadorMinimo, power5, tiempoIn5, tiempoOut5);
		}

		// Token: 0x04000B0D RID: 2829
		public bool parpadearFlag;

		// Token: 0x04000B0E RID: 2830
		public bool guiñarRFlag;

		// Token: 0x04000B0F RID: 2831
		public bool guiñarLFlag;

		// Token: 0x04000B10 RID: 2832
		public bool achiquitarFlag;

		// Token: 0x04000B11 RID: 2833
		public bool agrandarFlag;

		// Token: 0x04000B12 RID: 2834
		[ReadOnlyUI]
		[SerializeField]
		private float m_currentCerraduraDeOjoLMod;

		// Token: 0x04000B13 RID: 2835
		[ReadOnlyUI]
		[SerializeField]
		private float m_currentCerraduraDeOjoRMod;

		// Token: 0x04000B14 RID: 2836
		public ControlDeParpadeoValores forceValues;

		// Token: 0x04000B15 RID: 2837
		[NonSerialized]
		private ControlDeParpadeoValores m_forceValuesLast;

		// Token: 0x04000B16 RID: 2838
		[SerializeField]
		private ControlDeParpadeoValores m_ValoresEnviadosASkin;

		// Token: 0x04000B17 RID: 2839
		[SerializeField]
		private ControlDeParpadeoValores m_ValoresDespuesDeAnimacion;

		// Token: 0x04000B18 RID: 2840
		[SerializeField]
		private ControlDeParpadeo.ValoresNoControlados m_ValoresNoControladosDespuesDeAnimacion;

		// Token: 0x04000B19 RID: 2841
		[SerializeField]
		private ControlDeParpadeoValores m_ValoresDeCambio;

		// Token: 0x04000B1A RID: 2842
		[SerializeField]
		private ControlDeParpadeoValores m_valoresPermanentes;

		// Token: 0x04000B1B RID: 2843
		[ReadOnlyUI]
		[SerializeField]
		private ControlDeParpadeoValores m_ValoresPermanentesLast;

		// Token: 0x04000B1C RID: 2844
		[ReadOnlyUI]
		[SerializeField]
		private ControlDeParpadeo.Index m_Index;

		// Token: 0x04000B1D RID: 2845
		[ReadOnlyUI]
		[SerializeField]
		private ControlDeParpadeo.IndexNoControladosAnimados m_IndexNoControladosAnimados;

		// Token: 0x04000B1E RID: 2846
		[ReadOnlyUI]
		[SerializeField]
		private ControlDeParpadeo.IndexNoControladosNoAnimados m_IndexNoControladosNoAnimados;

		// Token: 0x04000B1F RID: 2847
		[SerializeField]
		private ControlDeParpadeo.Modificadores m_modificadores = new ControlDeParpadeo.Modificadores();

		// Token: 0x04000B20 RID: 2848
		private SkinnedMeshRenderer m_body;

		// Token: 0x04000B21 RID: 2849
		private IControladorDeAnimationBlendShapes m_controllador;

		// Token: 0x04000B22 RID: 2850
		private float m_BlinkL;

		// Token: 0x04000B23 RID: 2851
		private float m_BlinkR;

		// Token: 0x04000B24 RID: 2852
		private float m_BlinkTarget;

		// Token: 0x04000B25 RID: 2853
		private float m_SquintTarget;

		// Token: 0x04000B26 RID: 2854
		private float m_Enlarge;

		// Token: 0x04000B27 RID: 2855
		public ControlDeParpadeo.ModificablesDeValores modificadoresDeValoresForzados = new ControlDeParpadeo.ModificablesDeValores();

		// Token: 0x04000B28 RID: 2856
		public ControlDeParpadeoModificablesHolder modificableGeneral = new ControlDeParpadeoModificablesHolder();

		// Token: 0x04000B29 RID: 2857
		public ControlDeParpadeoModificablesHolder modificableDeParpadeo = new ControlDeParpadeoModificablesHolder();

		// Token: 0x04000B2A RID: 2858
		public ControlDeParpadeoModificablesHolder modificableDeGuiñoR = new ControlDeParpadeoModificablesHolder();

		// Token: 0x04000B2B RID: 2859
		public ControlDeParpadeoModificablesHolder modificableDeGuiñoL = new ControlDeParpadeoModificablesHolder();

		// Token: 0x04000B2C RID: 2860
		public ControlDeParpadeoModificablesHolder modificableDeAchiquitamiento = new ControlDeParpadeoModificablesHolder();

		// Token: 0x04000B2D RID: 2861
		public ControlDeParpadeoModificablesHolder modificableDeAgrandamiento = new ControlDeParpadeoModificablesHolder();

		// Token: 0x04000B2E RID: 2862
		public ControlDeParpadeo.ModsDeModificadoresHolder defaultModsGenerales = new ControlDeParpadeo.ModsDeModificadoresHolder();

		// Token: 0x04000B2F RID: 2863
		public ControlDeParpadeo.ModsDeModificadoresHolder nextModsDeParpadeo = new ControlDeParpadeo.ModsDeModificadoresHolder();

		// Token: 0x04000B30 RID: 2864
		public ControlDeParpadeo.ModsDeModificadoresHolder nextModsDeGuiñoR = new ControlDeParpadeo.ModsDeModificadoresHolder();

		// Token: 0x04000B31 RID: 2865
		public ControlDeParpadeo.ModsDeModificadoresHolder nextModsDeGuiñoL = new ControlDeParpadeo.ModsDeModificadoresHolder();

		// Token: 0x04000B32 RID: 2866
		public ControlDeParpadeo.ModsDeModificadoresHolder nextModsDeAchiquitamiento = new ControlDeParpadeo.ModsDeModificadoresHolder();

		// Token: 0x04000B33 RID: 2867
		public ControlDeParpadeo.ModsDeModificadoresHolder nextModsDeAgrandamiento = new ControlDeParpadeo.ModsDeModificadoresHolder();

		// Token: 0x04000B34 RID: 2868
		public ControlDeParpadeo.Config config = new ControlDeParpadeo.Config();

		// Token: 0x04000B35 RID: 2869
		private ControlDeParpadeo.EventosHolder m_parpadeoEventosHolder = new ControlDeParpadeo.EventosHolder();

		// Token: 0x04000B36 RID: 2870
		private ControlDeParpadeo.EventosHolder m_guiñarREventosHolder = new ControlDeParpadeo.EventosHolder();

		// Token: 0x04000B37 RID: 2871
		private ControlDeParpadeo.EventosHolder m_guiñarLEventosHolder = new ControlDeParpadeo.EventosHolder();

		// Token: 0x04000B38 RID: 2872
		private ControlDeParpadeo.EventosHolder m_achiquitamientoEventosHolder = new ControlDeParpadeo.EventosHolder();

		// Token: 0x04000B39 RID: 2873
		private ControlDeParpadeo.EventosHolder m_agrandamientoEventosHolder = new ControlDeParpadeo.EventosHolder();

		// Token: 0x0200024F RID: 591
		public class EventosHolder
		{
			// Token: 0x04000B3A RID: 2874
			public Action comienza;

			// Token: 0x04000B3B RID: 2875
			public Action medio;

			// Token: 0x04000B3C RID: 2876
			public Action termina;
		}

		// Token: 0x02000250 RID: 592
		[Serializable]
		public class ModificablesDeValores
		{
			// Token: 0x06000D6B RID: 3435 RVA: 0x0003E650 File Offset: 0x0003C850
			public ControlDeParpadeoValores Modificar(ControlDeParpadeoValores origen)
			{
				float num = ControlDeParpadeo.ModificablesDeValores.ModificarInvertido(this.blinkSumable, this.blink, this.blinkInvertido, origen.blink);
				float num2 = ControlDeParpadeo.ModificablesDeValores.ModificarInvertido(this.winkLSumable, this.winkL, this.winkLInvertido, origen.winkL);
				float num3 = ControlDeParpadeo.ModificablesDeValores.ModificarInvertido(this.winkRSumable, this.winkR, this.winkRInvertido, origen.winkR);
				float num4 = ControlDeParpadeo.ModificablesDeValores.ModificarInvertido(this.enlargeSumable, this.enlarge, this.enlargeInvertido, origen.enlarge);
				float num5 = ControlDeParpadeo.ModificablesDeValores.ModificarInvertido(this.squintSumable, this.squint, this.squintInvertido, origen.squint);
				origen.blink = num;
				origen.winkL = num2;
				origen.winkR = num3;
				origen.enlarge = num4;
				origen.squint = num5;
				return origen;
			}

			// Token: 0x06000D6C RID: 3436 RVA: 0x0003E720 File Offset: 0x0003C920
			private static float ModificarInvertido(ModificableDeFloat sumable, ModificableDeFloat directo, ModificableDeFloat invertido, float current)
			{
				float num = sumable.AdicinarValorIncluyendo(current);
				num = directo.ModificarValor(num);
				float num2 = 100f - num;
				num2 = invertido.ModificarValor(num2);
				return 100f - num2;
			}

			// Token: 0x04000B3D RID: 2877
			public ModificableDeFloat blinkSumable = new ModificableDeFloat(0f);

			// Token: 0x04000B3E RID: 2878
			public ModificableDeFloat winkLSumable = new ModificableDeFloat(0f);

			// Token: 0x04000B3F RID: 2879
			public ModificableDeFloat winkRSumable = new ModificableDeFloat(0f);

			// Token: 0x04000B40 RID: 2880
			public ModificableDeFloat enlargeSumable = new ModificableDeFloat(0f);

			// Token: 0x04000B41 RID: 2881
			public ModificableDeFloat squintSumable = new ModificableDeFloat(0f);

			// Token: 0x04000B42 RID: 2882
			public ModificableDeFloat blinkInvertido = new ModificableDeFloat(1f);

			// Token: 0x04000B43 RID: 2883
			public ModificableDeFloat winkLInvertido = new ModificableDeFloat(1f);

			// Token: 0x04000B44 RID: 2884
			public ModificableDeFloat winkRInvertido = new ModificableDeFloat(1f);

			// Token: 0x04000B45 RID: 2885
			public ModificableDeFloat enlargeInvertido = new ModificableDeFloat(1f);

			// Token: 0x04000B46 RID: 2886
			public ModificableDeFloat squintInvertido = new ModificableDeFloat(1f);

			// Token: 0x04000B47 RID: 2887
			public ModificableDeFloat blink = new ModificableDeFloat(1f);

			// Token: 0x04000B48 RID: 2888
			public ModificableDeFloat winkL = new ModificableDeFloat(1f);

			// Token: 0x04000B49 RID: 2889
			public ModificableDeFloat winkR = new ModificableDeFloat(1f);

			// Token: 0x04000B4A RID: 2890
			public ModificableDeFloat enlarge = new ModificableDeFloat(1f);

			// Token: 0x04000B4B RID: 2891
			public ModificableDeFloat squint = new ModificableDeFloat(1f);
		}

		// Token: 0x02000251 RID: 593
		[Serializable]
		public class ModsDeModificadoresHolder
		{
			// Token: 0x06000D6E RID: 3438 RVA: 0x0003E85B File Offset: 0x0003CA5B
			public void Init(ControlDeParpadeoModificablesHolder modificable, Component owner)
			{
				this.power = modificable.power.ObtenerModificadorNotNull(owner);
				this.tiempoIn = modificable.tiempoIn.ObtenerModificadorNotNull(owner);
				this.tiempoOut = modificable.tiempoOut.ObtenerModificadorNotNull(owner);
			}

			// Token: 0x06000D6F RID: 3439 RVA: 0x0003E894 File Offset: 0x0003CA94
			public void Reset()
			{
				this.power.valor.valor = 1f;
				this.tiempoIn.valor.valor = 1f;
				this.tiempoOut.valor.valor = 1f;
			}

			// Token: 0x06000D70 RID: 3440 RVA: 0x0003E8E0 File Offset: 0x0003CAE0
			public void SetVelocidadMod(float mod)
			{
				if (mod < 1f)
				{
					this.power.valor.valor = mod;
					this.tiempoIn.valor.valor = 1f;
					this.tiempoOut.valor.valor = 1f;
					return;
				}
				if (mod > 1f)
				{
					this.power.valor.valor = 1f;
					this.tiempoIn.valor.valor = 1f / mod;
					this.tiempoOut.valor.valor = 1f / mod;
				}
			}

			// Token: 0x04000B4C RID: 2892
			public ModificadorDeFloat power;

			// Token: 0x04000B4D RID: 2893
			public ModificadorDeFloat tiempoIn;

			// Token: 0x04000B4E RID: 2894
			public ModificadorDeFloat tiempoOut;
		}

		// Token: 0x02000252 RID: 594
		[Serializable]
		public class Modificadores
		{
			// Token: 0x04000B4F RID: 2895
			public ModificadorDeFloat blinkLR;

			// Token: 0x04000B50 RID: 2896
			public ModificadorDeFloat blinkL;

			// Token: 0x04000B51 RID: 2897
			public ModificadorDeFloat blinkR;

			// Token: 0x04000B52 RID: 2898
			public ModificadorDeFloat enlarge;

			// Token: 0x04000B53 RID: 2899
			public ModificadorDeFloat squint;
		}

		// Token: 0x02000253 RID: 595
		[Serializable]
		public struct Index
		{
			// Token: 0x04000B54 RID: 2900
			public int blinkLR;

			// Token: 0x04000B55 RID: 2901
			public int blinkL;

			// Token: 0x04000B56 RID: 2902
			public int blinkR;

			// Token: 0x04000B57 RID: 2903
			public int enlarge;

			// Token: 0x04000B58 RID: 2904
			public int squint;
		}

		// Token: 0x02000254 RID: 596
		[Serializable]
		public struct IndexNoControladosAnimados
		{
			// Token: 0x04000B59 RID: 2905
			public int cheekRaiseR;

			// Token: 0x04000B5A RID: 2906
			public int cheekRaiseL;
		}

		// Token: 0x02000255 RID: 597
		[Serializable]
		public struct IndexNoControladosNoAnimados
		{
			// Token: 0x04000B5B RID: 2907
			public int eyesRound;

			// Token: 0x04000B5C RID: 2908
			public int eyesThin;

			// Token: 0x04000B5D RID: 2909
			public int eyesTopFlat;

			// Token: 0x04000B5E RID: 2910
			public int topInMin;

			// Token: 0x04000B5F RID: 2911
			public int topInMax;

			// Token: 0x04000B60 RID: 2912
			public int bottomOutMin;

			// Token: 0x04000B61 RID: 2913
			public int bottomOutMax;
		}

		// Token: 0x02000256 RID: 598
		[Serializable]
		public struct ValoresNoControlados
		{
			// Token: 0x04000B62 RID: 2914
			[Range(0f, 100f)]
			public float cheekRaiseR;

			// Token: 0x04000B63 RID: 2915
			[Range(0f, 100f)]
			public float cheekRaiseL;

			// Token: 0x04000B64 RID: 2916
			[Range(0f, 100f)]
			public float eyesRound;

			// Token: 0x04000B65 RID: 2917
			[Range(0f, 100f)]
			public float eyesThin;

			// Token: 0x04000B66 RID: 2918
			[Range(0f, 100f)]
			public float eyesTopFlat;

			// Token: 0x04000B67 RID: 2919
			[Range(0f, 100f)]
			public float topInMin;

			// Token: 0x04000B68 RID: 2920
			[Range(0f, 100f)]
			public float topInMax;

			// Token: 0x04000B69 RID: 2921
			[Range(0f, 100f)]
			public float bottomOutMin;

			// Token: 0x04000B6A RID: 2922
			[Range(0f, 100f)]
			public float bottomOutMax;
		}

		// Token: 0x02000257 RID: 599
		[Serializable]
		public class Config
		{
			// Token: 0x04000B6B RID: 2923
			[Range(0f, 100f)]
			public float maxBlinkSiSquintMax = 78f;

			// Token: 0x04000B6C RID: 2924
			[Range(0f, 100f)]
			public float maxBlinkSiCheekRaiseMax = 81f;

			// Token: 0x04000B6D RID: 2925
			[Range(0f, 100f)]
			public float maxBlinkSiEyeThinMax = 67f;

			// Token: 0x04000B6E RID: 2926
			[Range(0f, 100f)]
			public float maxBlinkSiEyeTopFlatMax = 83f;

			// Token: 0x04000B6F RID: 2927
			[Range(0f, 100f)]
			public float maxBlinkSiTopInMax = 97f;

			// Token: 0x04000B70 RID: 2928
			[Range(0f, 100f)]
			public float maxBlinkSiBottomOutMax = 95f;

			// Token: 0x04000B71 RID: 2929
			public float blinkExtraNecesarioSiEnlargeMax = 27f;

			// Token: 0x04000B72 RID: 2930
			public float blinkExtraNecesarioSiBlinkMax;

			// Token: 0x04000B73 RID: 2931
			public float blinkExtraNecesarioSiEyeRoundMax = 29f;

			// Token: 0x04000B74 RID: 2932
			public float blinkExtraNecesarioSiTopInMin = 7f;

			// Token: 0x04000B75 RID: 2933
			public float blinkExtraNecesarioSiBottomOutMin = 8f;

			// Token: 0x04000B76 RID: 2934
			public ControlDeParpadeo.Config.ConfigDeAcion parpadeo = new ControlDeParpadeo.Config.ConfigDeAcion
			{
				modificadorMinimo = 0.075f,
				power = 3f,
				tiempoIn = 0.05f,
				tiempoOut = 0.0666f
			};

			// Token: 0x04000B77 RID: 2935
			public ControlDeParpadeo.Config.ConfigDeAcion guiño = new ControlDeParpadeo.Config.ConfigDeAcion
			{
				modificadorMinimo = 0.05f,
				power = 3f,
				tiempoIn = 0.13f,
				tiempoOut = 0.195f
			};

			// Token: 0x04000B78 RID: 2936
			public ControlDeParpadeo.Config.ConfigDeAcion achiquitamiento = new ControlDeParpadeo.Config.ConfigDeAcion
			{
				modificadorMinimo = 0.01f,
				power = 0.5f,
				tiempoIn = 0.1f,
				tiempoOut = 0.15f
			};

			// Token: 0x04000B79 RID: 2937
			public ControlDeParpadeo.Config.ConfigDeAcion agrandamiento = new ControlDeParpadeo.Config.ConfigDeAcion
			{
				modificadorMinimo = 0.05f,
				power = 0.75f,
				tiempoIn = 0.1f,
				tiempoOut = 0.15f
			};

			// Token: 0x04000B7A RID: 2938
			public ControlDeParpadeo.Config.ConfigsDeAcionGenerales generales = new ControlDeParpadeo.Config.ConfigsDeAcionGenerales();

			// Token: 0x02000258 RID: 600
			[Serializable]
			public class ConfigDeAcion
			{
				// Token: 0x04000B7B RID: 2939
				public float tiempoIn;

				// Token: 0x04000B7C RID: 2940
				public float tiempoOut;

				// Token: 0x04000B7D RID: 2941
				public float power;

				// Token: 0x04000B7E RID: 2942
				public float modificadorMinimo;
			}

			// Token: 0x02000259 RID: 601
			[Serializable]
			public class ConfigsDeAcionGenerales
			{
				// Token: 0x04000B7F RID: 2943
				public ControlDeParpadeo.Config.ConfigDeAcion parpadeo = new ControlDeParpadeo.Config.ConfigDeAcion
				{
					modificadorMinimo = 1f,
					power = 1f,
					tiempoIn = 0.11f,
					tiempoOut = 0.15f
				};

				// Token: 0x04000B80 RID: 2944
				public ControlDeParpadeo.Config.ConfigDeAcion guiño = new ControlDeParpadeo.Config.ConfigDeAcion
				{
					modificadorMinimo = 1f,
					power = 1f,
					tiempoIn = 0.15f,
					tiempoOut = 0.22500001f
				};

				// Token: 0x04000B81 RID: 2945
				public ControlDeParpadeo.Config.ConfigDeAcion achiquitamiento = new ControlDeParpadeo.Config.ConfigDeAcion
				{
					modificadorMinimo = 1f,
					power = 1f,
					tiempoIn = 0.12f,
					tiempoOut = 0.17999999f
				};

				// Token: 0x04000B82 RID: 2946
				public ControlDeParpadeo.Config.ConfigDeAcion agrandamiento = new ControlDeParpadeo.Config.ConfigDeAcion
				{
					modificadorMinimo = 1f,
					power = 1f,
					tiempoIn = 0.2f,
					tiempoOut = 0.3f
				};
			}
		}
	}
}
