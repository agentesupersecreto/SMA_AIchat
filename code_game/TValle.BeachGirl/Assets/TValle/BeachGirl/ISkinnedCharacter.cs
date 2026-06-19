using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Chars.Mapas;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using UnityEngine;

namespace Assets.TValle.BeachGirl
{
	// Token: 0x02000026 RID: 38
	public interface ISkinnedCharacter : IComponentStartable, IComponentAwakeable
	{
		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060000CC RID: 204
		IReadOnlyList<SkinnedMeshRenderer> mainSkinsRenderers { get; }

		// Token: 0x060000CD RID: 205
		TSkinAbstract AddSkin<TSkinAbstract, TSkin>(SkinnedMeshRenderer render, SkinConfig config, bool changeTransform, bool skinEsRendererParent, ICharacterSkinMeshConfig charConfig = null, Action<TSkinAbstract> beforeAdded = null, object extraData = null) where TSkinAbstract : Skin where TSkin : TSkinAbstract;

		// Token: 0x060000CE RID: 206
		TSkinAbstract AddSkin<TSkinAbstract>(Type skinType, SkinnedMeshRenderer render, SkinConfig config, bool changeTransform, bool skinEsRendererParent, ICharacterSkinMeshConfig charConfig = null, Action<TSkinAbstract> beforeAdded = null, object extraData = null, Transform ownArmature = null) where TSkinAbstract : Skin;
	}
}
