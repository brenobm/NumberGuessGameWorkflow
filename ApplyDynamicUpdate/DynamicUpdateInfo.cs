using NumberGuessWorkflowHost;
using System.Data;
using System.Data.SqlClient;
using System.Activities;
using System.Activities.DynamicUpdate;
using System.IO;
using System.Runtime.Serialization;
using System.Activities.DurableInstancing;

namespace ApplyDynamicUpdate
{
    class DynamicUpdateInfo
    {
        public DynamicUpdateMap updateMap;
        public WorkflowIdentity newIdentity;
    }
}
