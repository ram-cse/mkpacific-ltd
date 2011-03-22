public class AgentBUS
{
    internal static List<Agent> 		GetList(){}
    internal static bool 				AddItem(Agent newAgent){}
    internal static Agent 				GetItem(int id){}
    internal static bool 				Update(Agent agent){}
    internal static bool 				Remove(int id){}
}

public class AgentStateBUS
{
    internal static List<AgentState> 	GetList(){}
}

public class CollectMoneyBUS
{
    internal static bool 				CreateNew(int smId, int agentId){}
    internal static int 				GetProcessingAmount(int storeManagerId){}
    internal static int 				GetCollectedAmount(int storeManagerId){}
    private static string 				GenerateCollectNumber(){}
    internal static List<CollectMoney> 	GetListStatusId(int statusId){}
    internal static CollectMoney 		GetItem(int storeManagerId, int iStatusId, DateTime expireDate){}
    internal static bool 				Update(CollectMoney existCollectMoney, int agentId){}
}


public class CollectStateBUS
{
    internal static int 				GetId(string nameState){}
}

public class CustomerBUS
{
    internal static Customer 			getCustomerOrCreateNotYetBuy(string sPhone){}
    internal static Customer 			getCustomer(string sPhone){}
    internal static string 				GetPhone(int? customerId){}
}

public class CustomerStateBUS
{
    internal static int 				getId(string customerStatus){}
    internal static string 				getValue(int? iNullableID){}
}

public class InternetAccessRoleBUS
{
    internal static InternetAccessRole[]	GetArray(){}
}

public class PacificCodeBUS
{
    public static PacificCode 				SendMoney(string codeNumber, string Phone, double Amount){}
    public static PacificCode 				GetItem(string codeNumber){}
    internal static bool 					IsExist(string codeNumber){} 
	internal static string 					ChangeCode(string codeNumber){}
    internal static PacificCode 			GetLastPacificCode(int customerId){}
    internal static PacificCode[] 			GetList(){}
    internal static int 					GetTotalAmountOfStoreManager(int smId){}
    private static int 						GetTotalAmountOfStoreUser(int storeUserId){}
}

public class StoreManagerBUS
{
    internal static List<StoreManager> 		GetList(){}
    internal static StoreManager 			GetItem(int Id){}
    internal static int 					GetTotalLastMonthAmount(int managerId){}
    internal static int 					GetTotalLastMonthTransaction(int ManagerId){}
    internal static bool 					ChangeLocked(int Id){}
    internal static StoreManager[] 			GetList(string statusCode){}
    internal static bool 					Update(StoreManager editStoreManager){}
}

public class StoreManagerStateBUS
{
    public static string 					GetCode(int Id){}
    internal static StoreManagerState[] 	GetArray(){}
}

public class StoreUserBUS
{
    internal static StoreUser 				GetItem(int Id){}
    internal static StoreUser[] 			GetList(int managerId){}
}

public class TimeItemBUS
{
    internal static void 					AddIfNotExists(int storeManagerId){}
    private static string 					GetDay(int id){}
}

public class TimeTableBUS
{
    internal static List<TimeTable> 		GetArray(string dayName, int managerId){}
    internal static void 					Update(int managerId, List<TimeTable> lstTimeTable){}
}

public class TransactionBUS
{
    internal static bool 					isExist(string sCodeNumber){}
}
