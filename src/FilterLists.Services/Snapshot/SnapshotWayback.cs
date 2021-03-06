﻿using System.Threading.Tasks;
using FilterLists.Data;
using FilterLists.Services.GitHub;
using FilterLists.Services.Wayback;
using JetBrains.Annotations;

namespace FilterLists.Services.Snapshot
{
    public class SnapshotWayback : Snapshot
    {
        public SnapshotWayback()
        {
        }

        [UsedImplicitly]
        public SnapshotWayback(FilterListsDbContext dbContext, Data.Entities.FilterList list,
            GitHubService gitHubService, Logger logger, string uaString) :
            base(dbContext, list, gitHubService, logger, uaString)
        {
        }

        public override async Task TrySaveAsync()
        {
            await UpdateWaybackData();
            await TrySaveAsyncBase();
        }

        private async Task UpdateWaybackData()
        {
            var snapshotMeta = await WaybackService.GetMostRecentSnapshotMetaAsync(ListUrl);
            if (snapshotMeta != null)
            {
                ListUrl = SnapEntity.WaybackUrl = snapshotMeta.RawUrl;
                SnapEntity.WaybackTimestamp = snapshotMeta.TimestampUtc;
            }
            else
            {
                ListUrl = null;
            }
        }
    }
}