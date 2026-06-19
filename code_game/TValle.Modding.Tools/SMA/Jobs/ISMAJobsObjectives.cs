using System;
using System.Collections.Generic;

namespace Assets.TValle.Tools.Runtime.SMA.Jobs
{
	// Token: 0x0200001C RID: 28
	public interface ISMAJobsObjectives
	{
		// Token: 0x060000BE RID: 190
		ISMAJobObjective CreateObjective(string ID, string description, bool checkAfterCompleted, ObjectiveCheckerHandler checkDelegate, ObjectiveCheckFrequency checkFrequency, IReadOnlyList<ISMAJobObjective> subObjectives = null, string tips = null);

		// Token: 0x060000BF RID: 191
		ISMAJobObjective CreatePercentageObjective(string ID, string description, bool checkAfterCompleted, ObjectiveCheckerHandler_RecalculateWeight checkDelegate, ObjectiveCheckFrequency checkFrequency, IReadOnlyList<ISMAJobObjective> subObjectives = null, string tips = null, PercentageObjectiveProgressWeightChandedHandler callback = null);

		// Token: 0x060000C0 RID: 192
		ISMAJobObjective CreateFlagsObjective(string ID, string description, bool checkAfterCompleted, IReadOnlyList<string> Flags, ObjectiveCheckerHandler_IsFlagSet checkDelegate, ObjectiveCheckFrequency checkFrequency, IReadOnlyList<ISMAJobObjective> subObjectives = null, string tips = null, ObjectiveFlagsChandedHandler callback = null);

		// Token: 0x060000C1 RID: 193
		ISMAJobObjective CreateUniqueActionsCountObjective(string ID, string description, bool checkAfterCompleted, int Capacity, ObjectiveCheckerHandler_GetLastUniqueAction checkDelegate, ObjectiveCheckFrequency checkFrequency, IReadOnlyList<ISMAJobObjective> subObjectives = null, string tips = null, ObjectiveCountChandedHandler callback = null);

		// Token: 0x060000C2 RID: 194
		ISMAJobObjective CreateCountOfSingleActionObjective(string ID, string description, bool checkAfterCompleted, int Capacity, ObjectiveCheckerHandler_CurrentCount checkDelegate, ObjectiveCheckFrequency checkFrequency, IReadOnlyList<ISMAJobObjective> subObjectives = null, string tips = null, ObjectiveCountChandedHandler callback = null);

		// Token: 0x060000C3 RID: 195
		bool CheckCompleted();

		// Token: 0x060000C4 RID: 196
		void Status(out int totalRequiredObjectives, out int completedRequiredObjectives, out int totalOptionalObjectives, out int completedOptionalObjectives);

		// Token: 0x060000C5 RID: 197
		void StartSession();

		// Token: 0x060000C6 RID: 198
		void SessionStatus(out int totalRequiredObjectives, out int completedRequiredObjectives, out int totalOptionalObjectives, out int completedOptionalObjectives);

		// Token: 0x060000C7 RID: 199
		void EndSession();

		// Token: 0x060000C8 RID: 200
		void AddObjective(ISMAJobObjective objective, bool required, bool msgOnComplete);

		// Token: 0x060000C9 RID: 201
		void RemoveObjective(ISMAJobObjective objective);

		// Token: 0x060000CA RID: 202
		void AddObjectives(IReadOnlyList<ISMAJobObjective> objective, bool required);

		// Token: 0x060000CB RID: 203
		void RemoveObjectives(IReadOnlyList<ISMAJobObjective> objective);

		// Token: 0x060000CC RID: 204
		void RefreshUI();
	}
}
