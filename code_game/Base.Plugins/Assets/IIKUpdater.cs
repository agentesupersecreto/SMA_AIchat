using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
	// Token: 0x020000E7 RID: 231
	public interface IIKUpdater
	{
		// Token: 0x17000116 RID: 278
		// (get) Token: 0x06000638 RID: 1592
		// (set) Token: 0x06000639 RID: 1593
		bool physicsIKEnabled { get; set; }

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x0600063A RID: 1594
		// (set) Token: 0x0600063B RID: 1595
		bool ikEnabled { get; set; }

		// Token: 0x14000017 RID: 23
		// (add) Token: 0x0600063C RID: 1596
		// (remove) Token: 0x0600063D RID: 1597
		event Action<IIKUpdater> onFixingTransforms;

		// Token: 0x14000018 RID: 24
		// (add) Token: 0x0600063E RID: 1598
		// (remove) Token: 0x0600063F RID: 1599
		event Action<IIKUpdater> onFixedTransforms;

		// Token: 0x14000019 RID: 25
		// (add) Token: 0x06000640 RID: 1600
		// (remove) Token: 0x06000641 RID: 1601
		event Action<IIKUpdater> onAllIKsUpdating;

		// Token: 0x1400001A RID: 26
		// (add) Token: 0x06000642 RID: 1602
		// (remove) Token: 0x06000643 RID: 1603
		event IIKUpdateEventoHandler onSingleIKUpdating;

		// Token: 0x1400001B RID: 27
		// (add) Token: 0x06000644 RID: 1604
		// (remove) Token: 0x06000645 RID: 1605
		event IIKPassEventoHandler onSingleIKUpdatingJustPass0;

		// Token: 0x1400001C RID: 28
		// (add) Token: 0x06000646 RID: 1606
		// (remove) Token: 0x06000647 RID: 1607
		event IIKPassEventoHandler onSingleIKUpdatingJustPass1;

		// Token: 0x1400001D RID: 29
		// (add) Token: 0x06000648 RID: 1608
		// (remove) Token: 0x06000649 RID: 1609
		event IIKPassEventoHandler onSingleIKUpdatingJustPass2;

		// Token: 0x1400001E RID: 30
		// (add) Token: 0x0600064A RID: 1610
		// (remove) Token: 0x0600064B RID: 1611
		event IIKPassEventoHandler onSingleIKUpdatingJustPass3;

		// Token: 0x1400001F RID: 31
		// (add) Token: 0x0600064C RID: 1612
		// (remove) Token: 0x0600064D RID: 1613
		event IIKPassEventoHandler onSingleIKUpdatingPass1;

		// Token: 0x14000020 RID: 32
		// (add) Token: 0x0600064E RID: 1614
		// (remove) Token: 0x0600064F RID: 1615
		event IIKPassEventoHandler onSingleIKUpdatingPass2;

		// Token: 0x14000021 RID: 33
		// (add) Token: 0x06000650 RID: 1616
		// (remove) Token: 0x06000651 RID: 1617
		event IIKPassEventoHandler onSingleIKUpdatingPass3;

		// Token: 0x14000022 RID: 34
		// (add) Token: 0x06000652 RID: 1618
		// (remove) Token: 0x06000653 RID: 1619
		event IIKPassEventoHandler onSingleIKUpdatedPass1;

		// Token: 0x14000023 RID: 35
		// (add) Token: 0x06000654 RID: 1620
		// (remove) Token: 0x06000655 RID: 1621
		event IIKPassEventoHandler onSingleIKUpdatedPass2;

		// Token: 0x14000024 RID: 36
		// (add) Token: 0x06000656 RID: 1622
		// (remove) Token: 0x06000657 RID: 1623
		event IIKPassEventoHandler onSingleIKUpdatedPass3;

		// Token: 0x14000025 RID: 37
		// (add) Token: 0x06000658 RID: 1624
		// (remove) Token: 0x06000659 RID: 1625
		event IIKPassEventoHandler onSingleIKUpdatedPostPasses;

		// Token: 0x14000026 RID: 38
		// (add) Token: 0x0600065A RID: 1626
		// (remove) Token: 0x0600065B RID: 1627
		event IIKUpdateEventoHandler onSingleIKUpdated;

		// Token: 0x14000027 RID: 39
		// (add) Token: 0x0600065C RID: 1628
		// (remove) Token: 0x0600065D RID: 1629
		event Action<IIKUpdater> onAllIKsUpdated;

		// Token: 0x14000028 RID: 40
		// (add) Token: 0x0600065E RID: 1630
		// (remove) Token: 0x0600065F RID: 1631
		event Action<IIKUpdater> onPhysicsIKUpdating;

		// Token: 0x14000029 RID: 41
		// (add) Token: 0x06000660 RID: 1632
		// (remove) Token: 0x06000661 RID: 1633
		event Action<IIKUpdater> onPhysicsIKUpdated;

		// Token: 0x1400002A RID: 42
		// (add) Token: 0x06000662 RID: 1634
		// (remove) Token: 0x06000663 RID: 1635
		[Obsolete("", true)]
		event Action<IIKUpdater> iKsFixedTransforms;

		// Token: 0x1400002B RID: 43
		// (add) Token: 0x06000664 RID: 1636
		// (remove) Token: 0x06000665 RID: 1637
		[Obsolete("", true)]
		event Action<IIKUpdater> lookAtIKsBodyUpdating;

		// Token: 0x1400002C RID: 44
		// (add) Token: 0x06000666 RID: 1638
		// (remove) Token: 0x06000667 RID: 1639
		[Obsolete("", true)]
		event Action<IIKUpdater> lookAtIKsBodyUpdated;

		// Token: 0x1400002D RID: 45
		// (add) Token: 0x06000668 RID: 1640
		// (remove) Token: 0x06000669 RID: 1641
		[Obsolete("", true)]
		event Action<IIKUpdater> lookAtIKsHeadUpdating;

		// Token: 0x1400002E RID: 46
		// (add) Token: 0x0600066A RID: 1642
		// (remove) Token: 0x0600066B RID: 1643
		[Obsolete("", true)]
		event Action<IIKUpdater> lookAtIKsHeadUpdated;

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x0600066C RID: 1644
		IReadOnlyList<Component> sortedIKs { get; }

		// Token: 0x0600066D RID: 1645
		IReadOnlyList<Component> SortedIKsDeLayer(int layer);

		// Token: 0x0600066E RID: 1646
		int LayerDeIK(Component IK);

		// Token: 0x0600066F RID: 1647
		int InvertLayerDeIK(Component IK);

		// Token: 0x06000670 RID: 1648
		int IndexEnLayerDeIK(Component IK, out bool ultimoDeLayer);

		// Token: 0x06000671 RID: 1649
		void SwitchLayerIks(int layer);

		// Token: 0x06000672 RID: 1650
		int IDDeIK(Component IK);

		// Token: 0x06000673 RID: 1651
		[Obsolete("", true)]
		int InvertIDDeIK(Component IK);

		// Token: 0x06000674 RID: 1652
		Component IKDeID(int IKID);

		// Token: 0x06000675 RID: 1653
		bool IKEstaActivo(int IKID);

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06000676 RID: 1654
		int cantidadDeIKs { get; }

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x06000677 RID: 1655
		int cantidadDeLayers { get; }

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x06000678 RID: 1656
		int cantidadDeIKsActivos { get; }

		// Token: 0x06000679 RID: 1657
		int CantidadDePasadasDeIK(int IKID);

		// Token: 0x0600067A RID: 1658
		int CantidadDePasadasDeIK(Component IK);

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x0600067B RID: 1659
		bool esPhysicsIK { get; }

		// Token: 0x0600067C RID: 1660
		int CurrentPassIndexDeIK(int IKID);

		// Token: 0x0600067D RID: 1661
		int CurrentPassIndexDeIK(Component IK);
	}
}
