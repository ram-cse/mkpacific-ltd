Name="textBox1" 
tên lớp chung
	BUL
		+ AgentBUS => Business Object
	DAL
		+ AgentDAO => DataAccessObject
	DTO
		+ Agent
		hoặc AgentInfo
		
	LINQ:
		+ ElementAt(index)
		
		+ InsertOnSubmit
		+ InsertAllOnSubmit
		+ DeleteAllOnSubmit
		+ DeleteOnSubmit
		=> Update: sửa trực tiếp từ đối tượng, rồi SubmitChange();
	
	ADO Data Context
		+ AddObject(entity)
		+ DeleteObject(entity)
Quy định Các hàm sử dụng chung:

	// Truy xuat
	GetObject(id)

	// Thao tac co ban
	AddNew(entity)
	Update(entity)
	Remove(id)
	
	// Chuc nang ho tro
	IsExist(entity)
	IsExist(nameofattribute)
	GetList()
	GetList(condition)
	GetArray()
	GetArray(condition)

public class AgentDAO
{
    internal static List<Agent> 	GetList(){}
    internal static bool 			AddItem(Agent newAgent){}
    internal static Agent 			GetItem(int id){}
    internal static bool 			Update(Agent agent){}
    internal static bool 			Remove(int id){}
}

[THÔNG TIN NGƯỜI MỚI] - 



/*

*/
public class AgentStateDAO
{
    internal static AgentState[] 	GetArray(){}
}

public class CollectMoneyDAO
{
    internal static bool 			IsExist(string collectNumber){}
    internal static void 			AddItem(CollectMoney newCollectMoney){}
    internal static CollectMoney[] 	GetList(int storeManagerId){}
    internal static CollectMoney[]	GetListStatusId(int statusId){}
    internal static CollectMoney 	GetItem(int storeManagerId, int iStatusId, DateTime expireDate){}
    internal static bool 			Update(CollectMoney updateCollectMoney, int agentId){}
}

public class CollectStateDAO
{
    public static int 				GetId(string nameState){}
}


public class CustomerDAO
{
    internal static bool 			isExist(string sPhone){}
    internal static Customer 		getCustomer(string sPhone){}
    internal static Customer 		addNew(string sPhone){}
}

public class CustomerStateDAO
{
    internal static int 			getId(string customerStatus){}
    internal static string 			getCode(int? iId){}
    internal static string 			GetPhone(int? customerId){}
}

public class InternetAccessRoleDAO
{
    internal static InternetAccessRole[] GetArray(){}
}

public class PacificCodeDAO
{
    internal static bool 			IsExist(string codeNumber){}
    internal static PacificCode 	GetItem(string codeNumber){}
    internal static string 			ChangeCode(string codeNumber){}
    internal static void 			UpdateAmount(PacificCode pacificCode, int actualAmount){}
    internal static void 			AddItem(PacificCode newPacificCode){}
    internal static PacificCode 	GetLastPacificCode(int customerId){}
    internal static PacificCode[] 	GetList(){}
    internal static PacificCode[] 	GetArray(int storeUserId){}
}

public class StoreManagerDAO
{
    public static bool 					AddNew(StoreManager newStoreManager){}
    internal static List<StoreManager>	GetList(){}
    internal static StoreManager 		GetItem(int Id){}
    internal static bool 				ChangeLocked(int Id){}
    internal static StoreManager[] 		GetList(string statusCode){}
    internal static bool 				Update(StoreManager storeManager){}
}

public class StoreManagerStateDAO
{
    public 	 static int 				GetId(string codeState){}
    internal static string 				GetCode(int Id){}
    internal static StoreManagerState[]	GetArray(){}
}

public class StoreUserDAO
{
    internal static StoreUser 			GetItem(int Id){}
    internal static StoreUser[] 		GetArray(int ManagerId){}
    internal static int 				GetTotalLastMonthAmount(int storeId){}
    internal static int 				GetTotalLastMonthTranSaction(int storeUserId){}
}

public class TimeItemDAO
{
    internal static TimeItem 			GetItem(string day, int hour){}
    internal static void 				AddObject(TimeTable timeTable){}
}

public class TimeTableDAO
{
    internal static TimeTable 			GetItem(int timeItemId, int managerId){}
    internal static TimeTable[] 		GetArray(string dayName, int managerId){}
    internal static void 				Update(int managerId, int timeItemId, bool enabled){}
}