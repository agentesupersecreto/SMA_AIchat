using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x02000063 RID: 99
	public static class BodyPartEnumHelpler
	{
		// Token: 0x0600029E RID: 670 RVA: 0x000099C8 File Offset: 0x00007BC8
		public static bool ContieneHole(this IList<BodyPartEnum> partes)
		{
			for (int i = 0; i < partes.Count; i++)
			{
				if (partes[i].IsHole())
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600029F RID: 671 RVA: 0x000099F8 File Offset: 0x00007BF8
		public static bool ContieneCloseHole(this IList<BodyPartEnum> partes)
		{
			for (int i = 0; i < partes.Count; i++)
			{
				if (partes[i].IsCloseToHole())
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x00009A27 File Offset: 0x00007C27
		public static bool IsHole(this BodyPartEnum part)
		{
			return part == BodyPartEnum.bocaInterno || part - BodyPartEnum.anoHole <= 1 || part - BodyPartEnum.fondoVag <= 8;
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x00009A3E File Offset: 0x00007C3E
		public static bool IsCloseToHole(this BodyPartEnum part)
		{
			return part == BodyPartEnum.boca || part - BodyPartEnum.vagina <= 1 || part - BodyPartEnum.lengua <= 2;
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x00009A58 File Offset: 0x00007C58
		public static bool ContieneOrganHoleReadOnly(this IReadOnlyList<BodyPartEnum> partes)
		{
			for (int i = 0; i < partes.Count; i++)
			{
				if (partes[i].IsOrganHole())
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x00009A88 File Offset: 0x00007C88
		public static bool ContieneCloseOrganHoleReadOnly(this IReadOnlyList<BodyPartEnum> partes)
		{
			for (int i = 0; i < partes.Count; i++)
			{
				if (partes[i].IsCloseToOrganHole())
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x00009AB8 File Offset: 0x00007CB8
		public static bool ContieneOrganOrCloseOrganHoleReadOnly(this IReadOnlyList<BodyPartEnum> partes)
		{
			for (int i = 0; i < partes.Count; i++)
			{
				if (partes[i].IsCloseToOrganHole() || partes[i].IsOrganHole())
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x00009AF8 File Offset: 0x00007CF8
		public static bool ContieneOrganHole(this IList<BodyPartEnum> partes)
		{
			for (int i = 0; i < partes.Count; i++)
			{
				if (partes[i].IsOrganHole())
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x00009B28 File Offset: 0x00007D28
		public static bool ContieneCloseOrganHole(this IList<BodyPartEnum> partes)
		{
			for (int i = 0; i < partes.Count; i++)
			{
				if (partes[i].IsCloseToOrganHole())
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x00009B57 File Offset: 0x00007D57
		public static bool IsOrganHole(this BodyPartEnum part)
		{
			return part - BodyPartEnum.anoHole <= 1 || part - BodyPartEnum.fondoVag <= 8;
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x00009B6A File Offset: 0x00007D6A
		public static bool IsCloseToOrganHole(this BodyPartEnum part)
		{
			return part - BodyPartEnum.vagina <= 1 || part - BodyPartEnum.clitoris <= 1;
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x00009B80 File Offset: 0x00007D80
		public static int ViendoSkinLayer()
		{
			ConfiguracionGlobal.Layers layers = Singleton<ConfiguracionGeneral>.instance.layers;
			return layers.convexSkins.ToLayerMask() | layers.skins.ToLayerMask() | layers.holePrimario.ToLayerMask() | layers.holeSegundario.ToLayerMask() | layers.holeExtras.ToLayerMask() | layers.ground.ToLayerMask() | layers.@default.ToLayerMask() | layers.touchingHand.ToLayerMask() | layers.wall.ToLayerMask() | layers.superficieObstaculo.ToLayerMask();
		}

		// Token: 0x060002AA RID: 682 RVA: 0x00009C10 File Offset: 0x00007E10
		public static bool ViendoCollider(Vector3 camPosition, Collider collider, out RaycastHit hit)
		{
			int num = BodyPartEnumHelpler.ViendoSkinLayer();
			return BodyPartEnumHelpler.ViendoColliderBounds(camPosition, collider, num, out hit) || BodyPartEnumHelpler.ViendoColliderClosestPoint(camPosition, collider, num, out hit);
		}

		// Token: 0x060002AB RID: 683 RVA: 0x00009C40 File Offset: 0x00007E40
		public static bool ViendoColliderBounds(Vector3 camPosition, Collider collider, int layer, out RaycastHit hit)
		{
			Bounds bounds = collider.bounds;
			Vector3 vector = bounds.center - camPosition;
			if (BodyPartEnumHelpler.ViendoColliderEnDireccion(camPosition, collider, vector, layer, out hit))
			{
				return true;
			}
			Vector3 vector2 = bounds.min - camPosition;
			if (BodyPartEnumHelpler.ViendoColliderEnDireccion(camPosition, collider, vector2, layer, out hit))
			{
				return true;
			}
			Vector3 vector3 = bounds.max - camPosition;
			return BodyPartEnumHelpler.ViendoColliderEnDireccion(camPosition, collider, vector3, layer, out hit);
		}

		// Token: 0x060002AC RID: 684 RVA: 0x00009CAC File Offset: 0x00007EAC
		public static bool ViendoColliderClosestPoint(Vector3 camPosition, Collider collider, int layer, out RaycastHit hit)
		{
			if (collider is MeshCollider && !((MeshCollider)collider).convex)
			{
				hit = default(RaycastHit);
				return false;
			}
			Vector3 vector = collider.ClosestPoint(camPosition) - camPosition;
			return Physics.Raycast(camPosition, vector, out hit, vector.magnitude * 1.01f, layer, QueryTriggerInteraction.Ignore) && !(hit.point == Vector3.zero) && !(hit.collider != collider);
		}

		// Token: 0x060002AD RID: 685 RVA: 0x00009D24 File Offset: 0x00007F24
		public static bool ViendoColliderEnDireccion(Vector3 camPosition, Collider collider, Vector3 castDirection, int layer, out RaycastHit hit)
		{
			return Physics.Raycast(camPosition, castDirection, out hit, castDirection.magnitude * 1.01f, layer, QueryTriggerInteraction.Ignore) && !(hit.point == Vector3.zero) && !(hit.collider != collider);
		}

		// Token: 0x060002AE RID: 686 RVA: 0x00009D74 File Offset: 0x00007F74
		public static HitSkinBasica ViendoSkin(Vector3 puntoVisualDeCharacter, Vector3 direccionVisualDeCharacter, out RaycastHit hit, float range, int layer, float victimScale, float worldCastRadius = 0.015f)
		{
			if (!Physics.SphereCast(puntoVisualDeCharacter, worldCastRadius * victimScale, direccionVisualDeCharacter, out hit, range, layer, QueryTriggerInteraction.Ignore) || hit.point == Vector3.zero)
			{
				return null;
			}
			HitSkinBasica hitSkinBasica = hit.collider.GetComponentInParent<HitSkinBasica>();
			if (hitSkinBasica == null)
			{
				ColliderDeEmulatedHitSkin component = hit.collider.GetComponent<ColliderDeEmulatedHitSkin>();
				if (component == null)
				{
					return null;
				}
				hitSkinBasica = component.owner;
			}
			if (hitSkinBasica == null)
			{
				return null;
			}
			return hitSkinBasica;
		}

		// Token: 0x060002AF RID: 687 RVA: 0x00009DE8 File Offset: 0x00007FE8
		public static bool ViendoParametros(AnimatorCharacter character, out Vector3 puntoVisualDeCharacter, out Vector3 direccionVisualDeCharacter)
		{
			if (character.cameraAtadaTransform)
			{
				puntoVisualDeCharacter = character.cameraAtadaTransform.position;
				direccionVisualDeCharacter = character.cameraAtadaTransform.forward;
				return true;
			}
			if (character.bones.eyeL.transform && character.bones.eyeR.transform)
			{
				puntoVisualDeCharacter = character.bones.eyeL.transform.position + character.bones.eyeR.transform.position;
				puntoVisualDeCharacter /= 2f;
				direccionVisualDeCharacter = character.bones.eyeL.currentForward + character.bones.eyeR.currentForward;
				direccionVisualDeCharacter = direccionVisualDeCharacter.normalized;
				return true;
			}
			direccionVisualDeCharacter = (puntoVisualDeCharacter = Vector3.zero);
			return false;
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x00009EF4 File Offset: 0x000080F4
		public static bool ViendoParteDelCuerpo(Vector3 puntoVisualDeCharacter, Vector3 direccionVisualDeCharacter, float range, out HitSkinBasica siendoObservado, out RaycastHit hit, out ParteDelCuerpoHumano parte, out Side side, float victimScale, float precision = 0.015f)
		{
			parte = ParteDelCuerpoHumano.pecho;
			side = Side.none;
			hit = default(RaycastHit);
			siendoObservado = null;
			int num = BodyPartEnumHelpler.ViendoSkinLayer();
			siendoObservado = BodyPartEnumHelpler.ViendoSkin(puntoVisualDeCharacter, direccionVisualDeCharacter, out hit, range, num, victimScale, precision);
			if (siendoObservado == null)
			{
				return false;
			}
			if (siendoObservado.requiereBodyPartEnumCalculo != null)
			{
				parte = siendoObservado.requiereBodyPartEnumCalculo.Value.ParseAParteHumana();
				side = siendoObservado.side;
				return true;
			}
			HitSkin hitSkin = siendoObservado as HitSkin;
			if (hitSkin == null)
			{
				return false;
			}
			BodyPartEnum bodyPartEnum;
			if (!Singleton<FemaleHeroBodyPartHitCalculador>.instance.CalcularParteImpactada(hitSkin.hitParte, hit, out bodyPartEnum))
			{
				return false;
			}
			parte = bodyPartEnum.ParseAParteHumana();
			side = siendoObservado.side;
			return true;
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x00009FB0 File Offset: 0x000081B0
		public static Side ParseASide(this BodyPartEnum parte)
		{
			switch (parte)
			{
			case BodyPartEnum.cabeza:
			case BodyPartEnum.cuello:
			case BodyPartEnum.mandibula:
			case BodyPartEnum.boca:
			case BodyPartEnum.bocaInterno:
			case BodyPartEnum.nariz:
			case BodyPartEnum.frente:
			case BodyPartEnum.pecho:
			case BodyPartEnum.espalda:
			case BodyPartEnum.abdomen:
			case BodyPartEnum.cintura:
			case BodyPartEnum.coxis:
			case BodyPartEnum.vientre:
			case BodyPartEnum.vagina:
			case BodyPartEnum.perineo:
			case BodyPartEnum.anoHole:
			case BodyPartEnum.vagHole:
			case BodyPartEnum.hombligo:
			case BodyPartEnum.lengua:
			case BodyPartEnum.clitoris:
			case BodyPartEnum.labiosVaginales:
			case BodyPartEnum.fondoVag:
			case BodyPartEnum.fondoAnus:
			case BodyPartEnum.fondoBoca:
			case BodyPartEnum.anchoVag:
			case BodyPartEnum.anchoAnus:
			case BodyPartEnum.anchoBoca:
			case BodyPartEnum.entradaVag:
			case BodyPartEnum.entradaAnus:
			case BodyPartEnum.entradaBoca:
				return Side.none;
			case BodyPartEnum.mejilla_L:
			case BodyPartEnum.ojo_L:
			case BodyPartEnum.ojoInterno_L:
			case BodyPartEnum.ceja_L:
			case BodyPartEnum.ciene_L:
			case BodyPartEnum.hombro_L:
			case BodyPartEnum.axila_L:
			case BodyPartEnum.brazo_L:
			case BodyPartEnum.anteBrazo_L:
			case BodyPartEnum.mano_L:
			case BodyPartEnum.seno_L:
			case BodyPartEnum.pezon_L:
			case BodyPartEnum.cadera_L:
			case BodyPartEnum.nalga_L:
			case BodyPartEnum.pierna_L:
			case BodyPartEnum.rodilla_L:
			case BodyPartEnum.canilla_L:
			case BodyPartEnum.pie_L:
				return Side.L;
			case BodyPartEnum.mejilla_R:
			case BodyPartEnum.ojo_R:
			case BodyPartEnum.ojoInterno_R:
			case BodyPartEnum.ceja_R:
			case BodyPartEnum.ciene_R:
			case BodyPartEnum.hombro_R:
			case BodyPartEnum.axila_R:
			case BodyPartEnum.brazo_R:
			case BodyPartEnum.anteBrazo_R:
			case BodyPartEnum.mano_R:
			case BodyPartEnum.seno_R:
			case BodyPartEnum.pezon_R:
			case BodyPartEnum.cadera_R:
			case BodyPartEnum.nalga_R:
			case BodyPartEnum.pierna_R:
			case BodyPartEnum.rodilla_R:
			case BodyPartEnum.canilla_R:
			case BodyPartEnum.pie_R:
				return Side.R;
			default:
				throw new ArgumentOutOfRangeException(parte.ToString());
			}
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x0000A0E8 File Offset: 0x000082E8
		public static HumanBodyBones ParseAHumanBodyBones(this BodyPartEnum parte)
		{
			switch (parte)
			{
			case BodyPartEnum.cabeza:
				return HumanBodyBones.Head;
			case BodyPartEnum.cuello:
				return HumanBodyBones.Neck;
			case BodyPartEnum.mandibula:
				return HumanBodyBones.Jaw;
			case BodyPartEnum.boca:
				return HumanBodyBones.Jaw;
			case BodyPartEnum.bocaInterno:
				return HumanBodyBones.Head;
			case BodyPartEnum.nariz:
				return HumanBodyBones.Head;
			case BodyPartEnum.mejilla_L:
				return HumanBodyBones.Head;
			case BodyPartEnum.mejilla_R:
				return HumanBodyBones.Head;
			case BodyPartEnum.ojo_L:
				return HumanBodyBones.Head;
			case BodyPartEnum.ojo_R:
				return HumanBodyBones.Head;
			case BodyPartEnum.ojoInterno_L:
				return HumanBodyBones.LeftEye;
			case BodyPartEnum.ojoInterno_R:
				return HumanBodyBones.RightEye;
			case BodyPartEnum.ceja_L:
				return HumanBodyBones.Head;
			case BodyPartEnum.ceja_R:
				return HumanBodyBones.Head;
			case BodyPartEnum.ciene_L:
				return HumanBodyBones.Head;
			case BodyPartEnum.ciene_R:
				return HumanBodyBones.Head;
			case BodyPartEnum.frente:
				return HumanBodyBones.Head;
			case BodyPartEnum.pecho:
				return HumanBodyBones.Chest;
			case BodyPartEnum.espalda:
				return HumanBodyBones.Chest;
			case BodyPartEnum.hombro_L:
				return HumanBodyBones.LeftShoulder;
			case BodyPartEnum.hombro_R:
				return HumanBodyBones.RightShoulder;
			case BodyPartEnum.axila_L:
				return HumanBodyBones.LeftShoulder;
			case BodyPartEnum.axila_R:
				return HumanBodyBones.RightShoulder;
			case BodyPartEnum.brazo_L:
				return HumanBodyBones.LeftUpperArm;
			case BodyPartEnum.brazo_R:
				return HumanBodyBones.RightUpperArm;
			case BodyPartEnum.anteBrazo_L:
				return HumanBodyBones.LeftLowerArm;
			case BodyPartEnum.anteBrazo_R:
				return HumanBodyBones.RightLowerArm;
			case BodyPartEnum.mano_L:
				return HumanBodyBones.LeftHand;
			case BodyPartEnum.mano_R:
				return HumanBodyBones.RightHand;
			case BodyPartEnum.seno_L:
				return HumanBodyBones.Chest;
			case BodyPartEnum.seno_R:
				return HumanBodyBones.Chest;
			case BodyPartEnum.pezon_L:
				return HumanBodyBones.Chest;
			case BodyPartEnum.pezon_R:
				return HumanBodyBones.Chest;
			case BodyPartEnum.abdomen:
				return HumanBodyBones.Spine;
			case BodyPartEnum.cintura:
				return HumanBodyBones.Spine;
			case BodyPartEnum.cadera_L:
				return HumanBodyBones.Hips;
			case BodyPartEnum.cadera_R:
				return HumanBodyBones.Hips;
			case BodyPartEnum.coxis:
				return HumanBodyBones.Hips;
			case BodyPartEnum.vientre:
				return HumanBodyBones.Hips;
			case BodyPartEnum.nalga_L:
				return HumanBodyBones.Hips;
			case BodyPartEnum.nalga_R:
				return HumanBodyBones.Hips;
			case BodyPartEnum.vagina:
				return HumanBodyBones.Hips;
			case BodyPartEnum.perineo:
				return HumanBodyBones.Hips;
			case BodyPartEnum.anoHole:
				return HumanBodyBones.Hips;
			case BodyPartEnum.vagHole:
				return HumanBodyBones.Hips;
			case BodyPartEnum.hombligo:
				return HumanBodyBones.Spine;
			case BodyPartEnum.pierna_L:
				return HumanBodyBones.LeftUpperLeg;
			case BodyPartEnum.pierna_R:
				return HumanBodyBones.RightUpperLeg;
			case BodyPartEnum.rodilla_L:
				return HumanBodyBones.LeftLowerLeg;
			case BodyPartEnum.rodilla_R:
				return HumanBodyBones.RightLowerLeg;
			case BodyPartEnum.canilla_L:
				return HumanBodyBones.LeftLowerLeg;
			case BodyPartEnum.canilla_R:
				return HumanBodyBones.RightLowerLeg;
			case BodyPartEnum.pie_L:
				return HumanBodyBones.LeftFoot;
			case BodyPartEnum.pie_R:
				return HumanBodyBones.RightFoot;
			case BodyPartEnum.lengua:
				return HumanBodyBones.Jaw;
			case BodyPartEnum.clitoris:
				return HumanBodyBones.Hips;
			case BodyPartEnum.labiosVaginales:
				return HumanBodyBones.Hips;
			case BodyPartEnum.fondoVag:
				return HumanBodyBones.Hips;
			case BodyPartEnum.fondoAnus:
				return HumanBodyBones.Hips;
			case BodyPartEnum.fondoBoca:
				return HumanBodyBones.Head;
			case BodyPartEnum.anchoVag:
				return HumanBodyBones.Hips;
			case BodyPartEnum.anchoAnus:
				return HumanBodyBones.Hips;
			case BodyPartEnum.anchoBoca:
				return HumanBodyBones.Head;
			case BodyPartEnum.entradaVag:
			case BodyPartEnum.entradaAnus:
				return HumanBodyBones.Hips;
			case BodyPartEnum.entradaBoca:
				return HumanBodyBones.Head;
			default:
				throw new ArgumentOutOfRangeException(parte.ToString());
			}
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x0000A2BC File Offset: 0x000084BC
		public static ParteDelCuerpoHumano ParseAParteHumana(this BodyPartEnum parte)
		{
			switch (parte)
			{
			case BodyPartEnum.cabeza:
				return ParteDelCuerpoHumano.cabeza;
			case BodyPartEnum.cuello:
				return ParteDelCuerpoHumano.cuello;
			case BodyPartEnum.mandibula:
				return ParteDelCuerpoHumano.mandibula;
			case BodyPartEnum.boca:
				return ParteDelCuerpoHumano.labios;
			case BodyPartEnum.bocaInterno:
				return ParteDelCuerpoHumano.bocaInterno;
			case BodyPartEnum.nariz:
				return ParteDelCuerpoHumano.nariz;
			case BodyPartEnum.mejilla_L:
				return ParteDelCuerpoHumano.mejillas;
			case BodyPartEnum.mejilla_R:
				return ParteDelCuerpoHumano.mejillas;
			case BodyPartEnum.ojo_L:
				return ParteDelCuerpoHumano.ojos;
			case BodyPartEnum.ojo_R:
				return ParteDelCuerpoHumano.ojos;
			case BodyPartEnum.ojoInterno_L:
				return ParteDelCuerpoHumano.globosOculares;
			case BodyPartEnum.ojoInterno_R:
				return ParteDelCuerpoHumano.globosOculares;
			case BodyPartEnum.ceja_L:
				return ParteDelCuerpoHumano.cejas;
			case BodyPartEnum.ceja_R:
				return ParteDelCuerpoHumano.cejas;
			case BodyPartEnum.ciene_L:
				return ParteDelCuerpoHumano.cienes;
			case BodyPartEnum.ciene_R:
				return ParteDelCuerpoHumano.cienes;
			case BodyPartEnum.frente:
				return ParteDelCuerpoHumano.frente;
			case BodyPartEnum.pecho:
				return ParteDelCuerpoHumano.pecho;
			case BodyPartEnum.espalda:
				return ParteDelCuerpoHumano.espalda;
			case BodyPartEnum.hombro_L:
				return ParteDelCuerpoHumano.hombros;
			case BodyPartEnum.hombro_R:
				return ParteDelCuerpoHumano.hombros;
			case BodyPartEnum.axila_L:
				return ParteDelCuerpoHumano.axilas;
			case BodyPartEnum.axila_R:
				return ParteDelCuerpoHumano.axilas;
			case BodyPartEnum.brazo_L:
				return ParteDelCuerpoHumano.brazos;
			case BodyPartEnum.brazo_R:
				return ParteDelCuerpoHumano.brazos;
			case BodyPartEnum.anteBrazo_L:
				return ParteDelCuerpoHumano.anteBrazos;
			case BodyPartEnum.anteBrazo_R:
				return ParteDelCuerpoHumano.anteBrazos;
			case BodyPartEnum.mano_L:
				return ParteDelCuerpoHumano.manos;
			case BodyPartEnum.mano_R:
				return ParteDelCuerpoHumano.manos;
			case BodyPartEnum.seno_L:
				return ParteDelCuerpoHumano.senos;
			case BodyPartEnum.seno_R:
				return ParteDelCuerpoHumano.senos;
			case BodyPartEnum.pezon_L:
				return ParteDelCuerpoHumano.pezones;
			case BodyPartEnum.pezon_R:
				return ParteDelCuerpoHumano.pezones;
			case BodyPartEnum.abdomen:
				return ParteDelCuerpoHumano.abdomen;
			case BodyPartEnum.cintura:
				return ParteDelCuerpoHumano.cintura;
			case BodyPartEnum.cadera_L:
				return ParteDelCuerpoHumano.caderas;
			case BodyPartEnum.cadera_R:
				return ParteDelCuerpoHumano.caderas;
			case BodyPartEnum.coxis:
				return ParteDelCuerpoHumano.coxis;
			case BodyPartEnum.vientre:
				return ParteDelCuerpoHumano.vientre;
			case BodyPartEnum.nalga_L:
				return ParteDelCuerpoHumano.nalgas;
			case BodyPartEnum.nalga_R:
				return ParteDelCuerpoHumano.nalgas;
			case BodyPartEnum.vagina:
				return ParteDelCuerpoHumano.vientreBajo;
			case BodyPartEnum.perineo:
				return ParteDelCuerpoHumano.perineo;
			case BodyPartEnum.anoHole:
				return ParteDelCuerpoHumano.ano;
			case BodyPartEnum.vagHole:
				return ParteDelCuerpoHumano.vag;
			case BodyPartEnum.hombligo:
				return ParteDelCuerpoHumano.hombligo;
			case BodyPartEnum.pierna_L:
				return ParteDelCuerpoHumano.piernas;
			case BodyPartEnum.pierna_R:
				return ParteDelCuerpoHumano.piernas;
			case BodyPartEnum.rodilla_L:
				return ParteDelCuerpoHumano.rodillas;
			case BodyPartEnum.rodilla_R:
				return ParteDelCuerpoHumano.rodillas;
			case BodyPartEnum.canilla_L:
				return ParteDelCuerpoHumano.canillas;
			case BodyPartEnum.canilla_R:
				return ParteDelCuerpoHumano.canillas;
			case BodyPartEnum.pie_L:
				return ParteDelCuerpoHumano.pies;
			case BodyPartEnum.pie_R:
				return ParteDelCuerpoHumano.pies;
			case BodyPartEnum.lengua:
				return ParteDelCuerpoHumano.lengua;
			case BodyPartEnum.clitoris:
				return ParteDelCuerpoHumano.clitoris;
			case BodyPartEnum.labiosVaginales:
				return ParteDelCuerpoHumano.labiosVaginales;
			case BodyPartEnum.fondoVag:
			case BodyPartEnum.anchoVag:
			case BodyPartEnum.entradaVag:
				return ParteDelCuerpoHumano.vag;
			case BodyPartEnum.fondoAnus:
			case BodyPartEnum.anchoAnus:
			case BodyPartEnum.entradaAnus:
				return ParteDelCuerpoHumano.ano;
			case BodyPartEnum.fondoBoca:
			case BodyPartEnum.anchoBoca:
			case BodyPartEnum.entradaBoca:
				return ParteDelCuerpoHumano.bocaInterno;
			default:
				throw new ArgumentOutOfRangeException(parte.ToString());
			}
		}
	}
}
