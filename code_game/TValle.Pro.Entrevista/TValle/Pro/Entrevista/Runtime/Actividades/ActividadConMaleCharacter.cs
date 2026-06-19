using System;
using System.Collections;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.ScenaManagers;
using Assets._ReusableScripts.Globales;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x02000111 RID: 273
	public abstract class ActividadConMaleCharacter : TValleActividadSavedWithinTheScene
	{
		// Token: 0x170000ED RID: 237
		// (get) Token: 0x0600096D RID: 2413 RVA: 0x00037ECE File Offset: 0x000360CE
		public sealed override Character mainPlayerCharacter
		{
			get
			{
				return this.m_maleCharacter;
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x0600096E RID: 2414 RVA: 0x00037ED6 File Offset: 0x000360D6
		public sealed override Character mainNonPlayerCharacter
		{
			get
			{
				return null;
			}
		}

		// Token: 0x0600096F RID: 2415 RVA: 0x00037ED9 File Offset: 0x000360D9
		protected override IEnumerator OnStart()
		{
			if (CurrentMainCharacter<CurrentMainChar, MainChar>.current.character == null)
			{
				yield return this.InstantiateMaleCharacter(delegate(MaleChar c)
				{
					this.m_maleCharacter = c;
				});
			}
			else
			{
				this.m_maleCharacter = CurrentMainCharacter<CurrentMainChar, MainChar>.current.character as MaleChar;
				Transform transform = Singleton<GoToScenaManager>.instance.Obtener("MainOriginal_GoTo").transform;
				Transform transform2 = Singleton<GoToScenaManager>.instance.Obtener("Original_GoTo").transform;
				if (ExtendedMonoBehaviour.AlmostEqual(this.m_maleCharacter.rootBoneTransform.position, transform2.position, 0.1f))
				{
					this.m_maleCharacter.SetPositionAndRotation(transform);
				}
			}
			if (this.m_maleCharacter == null)
			{
				throw new ArgumentNullException("m_maleCharacter", "m_maleCharacter null reference.");
			}
			this.OnMainPlayerChanged(this.m_maleCharacter, null);
			yield break;
		}

		// Token: 0x06000970 RID: 2416
		protected abstract IEnumerator InstantiateMaleCharacter(Action<MaleChar> result);

		// Token: 0x06000971 RID: 2417 RVA: 0x00037EE8 File Offset: 0x000360E8
		protected override IEnumerator OnEnd()
		{
			LoaderDeNpcMasculinos.SaveToMemory(GlobalSingletonV2<MemoriaJson>.instance, this.m_maleCharacter);
			yield break;
		}

		// Token: 0x04000534 RID: 1332
		[ReadOnlyUI]
		[SerializeField]
		private MaleChar m_maleCharacter;
	}
}
