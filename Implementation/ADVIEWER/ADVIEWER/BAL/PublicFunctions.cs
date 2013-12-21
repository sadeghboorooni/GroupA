using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;
using System.Globalization;
using ADVIEWER.DAL;


namespace ADVIEWER.BAL
{
    public class PublicFunctions
    {
        public static AssignorClass MakeAssignor<EntityClass, AssignorClass>(EntityClass EntityObject)
        {

            AssignorClass AssignorObject = (AssignorClass)Activator.CreateInstance(typeof(AssignorClass));

            IList<PropertyInfo> EntityClass_props = new List<PropertyInfo>(EntityObject.GetType().GetProperties());
            IList<PropertyInfo> Assignor_props = new List<PropertyInfo>(AssignorObject.GetType().GetProperties());

            foreach (PropertyInfo Assignor_prop in Assignor_props)
            {
                if (Assignor_prop.GetSetMethod() != null &&
                    (Assignor_prop.PropertyType.BaseType.Name == "Object" || Assignor_prop.PropertyType.BaseType.Name == "ValueType"))
                {
                    PropertyInfo EntityClass_prop = EntityClass_props.Where(t => t.Name == Assignor_prop.Name).First();
                    var propValue = EntityClass_prop.GetValue(EntityObject, null);

                    Assignor_prop.SetValue(AssignorObject, propValue, null);
                }

            }

            return AssignorObject;
        }

        public static AssignorAdvertisment[] GetLast9Advs()
        {

            ModelContainer ml = new ModelContainer();
            List<AssignorAdvertisment> aAdv = new List<AssignorAdvertisment>();
            foreach (Advertisment ad in ml.Advertisments.Where(t => t.IsConfirmed).OrderByDescending(t => t.RegistrationDate).Take(12))
            {
                aAdv.Add(PublicFunctions.MakeAssignor<Advertisment, AssignorAdvertisment>(ad));
            }
            
            return PublicFunctions.SortByRate( aAdv.ToArray());
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            FieldInfo[] Props = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (FieldInfo prop in Props)
            {
                //Setting column names as Property names _solved_ and columnType
                dataTable.Columns.Add(prop.Name, prop.FieldType);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        internal static Single GetAdvAverageRate(int AdvId)
        {
            ModelContainer ml = new ModelContainer();

            Single result = 0;

            if (ml.Rates.Where(t => t.AdvertismentId == AdvId).Count() > 0)
            {
                result = (Single)ml.Rates.Where(t => t.AdvertismentId == AdvId).Average(t => t.Value);
            }
            return result;
        }

        public static AssignorStateCity[] GetStatesAndCities()
        {
            ModelContainer ml = new ModelContainer();

            List<AssignorStateCity> aSta = new List<AssignorStateCity>();
            foreach (StateCity sc in ml.StateCities.Where(t => t.StateId == null))
            {
                aSta.Add(MakeAssignor<StateCity, AssignorStateCity>(sc));
            }

            return aSta.ToArray();
        }
        public static AssignorAdvertisment[] GetAdvByStateID(int ID)
        {
            ModelContainer ml = new ModelContainer();
            List<AssignorAdvertisment> aAdv = new List<AssignorAdvertisment>();

            if (ml.StateCities.Where(t => t.ID == ID).First().StateId == null)
            {
                foreach (Advertisment adv1 in (from adv in ml.Advertisments
                                               where (adv.StateCityID == ID || adv.StateCityID == (from st in ml.StateCities where st.StateId == ID select st.ID).FirstOrDefault()) && adv.IsConfirmed == true
                                               select adv))
                {
                    aAdv.Add(PublicFunctions.MakeAssignor<Advertisment, AssignorAdvertisment>(adv1));
                }
            }
            else
                foreach (Advertisment adv1 in ml.Advertisments.Where(t => t.StateCityID == ID && t.IsConfirmed == true))
                {
                    aAdv.Add(PublicFunctions.MakeAssignor<Advertisment, AssignorAdvertisment>(adv1));
                }


            return aAdv.ToArray();
        }
        public static List<StateAndCitiesForReapeater> GetStatesWithCities()
        {
            ModelContainer ml = new ModelContainer();
            List<StateCity> AllState = ml.StateCities.Where(t => t.StateId == null).OrderBy(t => t.Name).ToList();
            List<StateAndCitiesForReapeater> ReturnListOfClasses = new List<StateAndCitiesForReapeater>();
            foreach (StateCity AS in AllState)
            {
                StateAndCitiesForReapeater Temp = new StateAndCitiesForReapeater(AS.ID);
                ReturnListOfClasses.Add(Temp);
            }
            return ReturnListOfClasses;
        }
        public static string SolarDateConvertor(object InputDate, int Mode = 2, string type = "")
        {
            Persia.SolarDate solarDate;
            try
            {
                solarDate = Persia.Calendar.ConvertToPersian(DateTime.Parse(InputDate.ToString()));
            }
            catch
            {
                solarDate = Persia.Calendar.ConvertToPersian(DateTime.ParseExact(InputDate.ToString(), "dd/MM/yyyy", new CultureInfo("en-US")));
            }
            if (1 == Mode)
            {
                /*
                 D = X  روز پیش
                 TY = امروز، دیروز، x   روز پیش
                 p = اکنون، x  دقیقه پیش، x  ساعت پیش
                 */
                return solarDate.ToRelativeDateString("TY");
            }
            else if (2 == Mode)
            {
                /*
                 D = ۱۳۸۹/۹/۳۰
                 d = ۸۹/۹/۳۰
                 W = سه شنبه  ۱۳۸۹/۹/۳۰
                 M = ۳۰ آذر ۱۳۸۹
                 H =   ۱۹  : ۵۰
                 
                 */
                if (null == type || "" == type)
                    return solarDate.ToString("D") + " ساعت " + solarDate.ToString("H");
                return solarDate.ToString(type);
            }
            else
                return solarDate.ToString("D");
        }

        internal static int CountOfRates(int AdvId)
        {
            ModelContainer ml = new ModelContainer();
            return ml.Rates.Where(t => t.AdvertismentId == AdvId).Count();
        }

        public static AssignorComment[] GetAdvComments(int AdvID)
        {
            ModelContainer ml = new ModelContainer();
            List<AssignorComment> TempAssignorComments = new List<AssignorComment>();
            foreach (Comment Cm in ml.Messages.OfType<Comment>().Where(t => t.AdvID == AdvID && t.IsConfirmed).ToArray())
            {
                TempAssignorComments.Add(PublicFunctions.MakeAssignor<Comment, AssignorComment>(Cm));
            }
            return TempAssignorComments.OrderByDescending(t=> t.RegistrationDate).ToArray();
        }

        public static void SetComment(int AdvID, string Text, string Email, int UserID)
        {
            ModelContainer ml = new ModelContainer();
            Comment TempCm = new Comment();

            TempCm.AdvID = AdvID;
            TempCm.RegistrationDate = DateTime.Now;
            TempCm.Email = Email;
            TempCm.SenderID = UserID;
            if (UserID == -1)
                TempCm.SenderID = null;
            TempCm.Text = Text;
            TempCm.IsConfirmed = false;

            ml.AddToMessages(TempCm);
            ml.SaveChanges();
        }

        public struct Wight {public double wr;public AssignorAdvertisment adv;}

        public static AssignorAdvertisment[] SortByRate(AssignorAdvertisment[] AdvList)
        {
            AdvList.OrderBy(T => T.ID);
            ModelContainer ml  = new ModelContainer();
            double min = 1;
            double c = 1.7;
            double rate;
            double voter;
            int size = AdvList.Count();
            Wight[]  SortedList = new Wight[size];



            for (int i = 0; i < size;i++ )
            {
                AssignorAdvertisment advs = AdvList[i];
                Wight wgt = new Wight();
                rate = GetAdvAverageRate(advs.ID);
                voter = ml.Rates.Where(t => t.AdvertismentId == advs.ID).Count();
                wgt.wr = (voter / (voter + min)) * rate + (min / (voter + min)) * c;
                wgt.adv = advs;
                SortedList[i] = wgt;
            
            }
            Array.Sort(SortedList, (x, y) => y.wr.CompareTo(x.wr));
            AssignorAdvertisment[] RetList = new AssignorAdvertisment [size] ;
            for (int j = 0; j < size; j++)
            {
                RetList[j] = SortedList[j].adv;
            }
            AssignorAdvertisment[] FinalList = new AssignorAdvertisment[size];
            int idx = 0;
            int pos = 0;
            for (int k = size/2 + (int)size/8; k >( size /4); k--)
            {
                if (pos >= k)
                    break;
                FinalList[idx] = RetList[k];
                FinalList[idx + 1] = RetList[pos];
                pos++;
                idx+=2;
            }
       //     for (int k = 0; k <= size / 4; k++)
        //    {
        //        FinalList[idx] = RetList[k];
        //        idx++;
         //   }
            for (int k = idx; k < size; k++)
            {
                FinalList[idx] = RetList[k];
                idx++;
            }

            return FinalList; 
        }
    }

        public class StateAndCitiesForReapeater
        {
            private int Id;

            public int ID
            {
                get { return Id; }
                set { Id = value; }
            }
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            private StateCity[] cities;

            public StateCity[] Cities
            {
                get { return cities; }
                set { cities = value; }
            }

            public StateAndCitiesForReapeater(int ID)
            {
                ModelContainer ml = new ModelContainer();
                this.ID = ID;
                this.Name = ml.StateCities.Where(t => t.ID == ID).First().Name;
                SetCities();
            }

            private void SetCities()
            {
                ModelContainer ml = new ModelContainer();
                Cities = ml.StateCities.Where(t => t.StateId == this.ID).OrderBy(t => t.Name).ToArray();
            }
        }

        public class AssignorParent
        {
            private int Id;

            public int ID
            {
                get { return Id; }
                set
                {
                    Id = value;
                }
            }

        }

        public class AssignorTicket : AssignorParent
        {
            private string _answer;

            public string Answer
            {
                get { return _answer; }
                set { _answer = value; }
            }

            private DateTime _lastUpdate;

            public DateTime LastUpdate
            {
                get { return _lastUpdate; }
                set { _lastUpdate = value; }
            }

            private DateTime _regDate;

            public DateTime RegDate
            {
                get { return _regDate; }
                set { _regDate = value; }
            }

            private string _text;

            public string Text
            {
                get { return _text; }
                set { _text = value; }
            }

            private string _title;

            public string Title
            {
                get { return _title; }
                set { _title = value; }
            }

            private int _userId;

            public int UserID
            {
                get { return _userId; }
                set { _userId = value; _setUser(); }
            }

            private AssignorUser _user;

            public AssignorUser User
            {
                get { return _user; }
            }

            private void _setUser()
            {
                ModelContainer ml = new ModelContainer();
                _user = PublicFunctions.MakeAssignor<User, AssignorUser>(ml.Users.Where(t => t.ID == _userId).First());
            }
        }
        public class AssignorRate : AssignorParent
        {
            private int _advertismentId;

            public int AdvertismentId
            {
                get { return _advertismentId; }
                set { _advertismentId = value; }
            }

            private Single _value;

            public Single Value
            {
                get { return _value; }
                set { _value = value; }
            }
        }
        public class AssignorUser
        {
            private int _id;

            public int ID
            {
                get { return _id; }
                set { _id = value; _setUserGroups(); }
            }

            private void _setUserGroups()
            {
                List<AssignorGroup> userG = new List<AssignorGroup>();
                ModelContainer ml = new ModelContainer();
                foreach (Group g in ml.Users.Where(t => t.ID == this.ID).First().Groups)
                {
                    userG.Add(PublicFunctions.MakeAssignor<Group, AssignorGroup>(g));
                }

                _userGroups = userG.ToArray();
            }

            private AssignorGroup[] _userGroups;

            public AssignorGroup[] Groups
            {
                get { return _userGroups; }
            }
            private string _about;

            public string About
            {
                get { return _about; }
                set { _about = value; }
            }

            private string _address;

            public string Address
            {
                get { return _address; }
                set { _address = value; }
            }

            private string _fax;

            public string Fax
            {
                get { return _fax; }
                set { _fax = value; }
            }

            private string _fullName;

            public string FullName
            {
                get { return _fullName; }
                set { _fullName = value; }
            }

            private string _mail;

            public string Mail
            {
                get { return _mail; }
                set { _mail = value; }
            }

            private string _mobile;

            public string Mobile
            {
                get { return _mobile; }
                set { _mobile = value; }
            }

            private string _picAddress;

            public string PicAddress
            {
                get { return _picAddress; }
                set { _picAddress = value; }
            }

            private string _tell;

            public string Tell
            {
                get { return _tell; }
                set { _tell = value; }
            }

            private string _yahooId;

            public string YahooID
            {
                get { return _yahooId; }
                set { _yahooId = value; }
            }


        }
        public class AssignorAdvertisment : AssignorParent
        {

            private Boolean _isConfirmed;

            public Boolean IsConfirmed
            {
                get { return _isConfirmed; }
                set { _isConfirmed = (bool)value; }
            }

            private bool _isRead;

            public bool IsRead
            {
                get { return _isRead; }
                set { _isRead = value; }
            }

            private int _userId;

            public int UserId
            {
                get { return _userId; }
                set { _userId = value; _setUser(); }
            }

            private AssignorUser _user;

            public AssignorUser User
            {
                get { return _user; }
            }

            private void _setUser()
            {
                ModelContainer ml = new ModelContainer();
                _user = PublicFunctions.MakeAssignor<User, AssignorUser>(ml.Users.Where(t => t.ID == _userId).First());
            }

            private int _groupId;

            public int GroupID
            {
                get { return _groupId; }
                set { _groupId = value; }
            }

            private string _title;

            public string Title
            {
                get { return _title; }
                set { _title = value; }
            }

            private string _pic;

            public string Pic
            {
                get { return _pic; }
                set { _pic = value; }
            }

            private string _fullName;

            public string FullName
            {
                get { return _fullName; }
                set { _fullName = value; }
            }

            private string _mobile;

            public string Mobile
            {
                get { return _mobile; }
                set { _mobile = value; }
            }

            private string _tell;

            public string Tell
            {
                get { return _tell; }
                set { _tell = value; }
            }

            private string _description;

            public string Description
            {
                get { return _description; }
                set { _description = value; }
            }

            private string _tellTime;

            public string TellTime
            {
                get { return _tellTime; }
                set { _tellTime = value; }
            }

            private string _email;

            public string Email
            {
                get { return _email; }
                set { _email = value; }
            }

            private int _reviewCount;

            public int ReviewCount
            {
                get { return _reviewCount; }
                set { _reviewCount = value; }
            }

            private string _price;

            public string Price
            {
                get { return _price; }
                set { _price = value; }
            }

            private DateTime _registrationDate;

            public DateTime RegistrationDate
            {
                get { return _registrationDate; }
                set { _registrationDate = value; }
            }

            private DateTime _lastRenewal;

            public DateTime LastRenewal
            {
                get { return _lastRenewal; }
                set { _lastRenewal = value; }
            }

            private DateTime _expirationDate;

            public DateTime ExpirationDate
            {
                get { return _expirationDate; }
                set { _expirationDate = value; }
            }

            private int _advDuration;

            public int AdvDuration
            {
                get { return _advDuration; }
                set { _advDuration = value; }
            }

            private int _starCount;

            public int StarCount
            {
                get { return _starCount; }
                set { _starCount = value; }
            }
        }
        public class AssignorGroup : AssignorParent
        {
            private string _groupName;

            public string GroupName
            {
                get { return _groupName; }
                set { _groupName = value; }
            }

            private int? parentID;

            public int? ParentID
            {
                get { return parentID; }
                set { parentID = value; _setParentGroup(); }
            }

            private AssignorGroup _parentGroup;

            public AssignorGroup ParentGroup
            {
                get { return _parentGroup; }
            }

            private void _setParentGroup()
            {
                if (parentID != null)
                {
                    ModelContainer ml = new ModelContainer();
                    _parentGroup = PublicFunctions.MakeAssignor<Group, AssignorGroup>(ml.Groups.Where(t => t.ID == parentID).First());
                }
            }
        }
        public class AssignorStateCity : AssignorParent
        {
            private string _name;

            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }

            private int? _stateId;

            public int? StateId
            {
                get { return _stateId; }
                set { _stateId = value; _setState(); }
            }

            private void _setState()
            {
                if (_stateId != null)
                {
                    ModelContainer ml = new ModelContainer();
                    _state = PublicFunctions.MakeAssignor<StateCity, AssignorStateCity>(ml.StateCities.Where(t => t.ID == _stateId).First());
                }
            }

            private AssignorStateCity _state;

            public AssignorStateCity State
            {
                get { return _state; }
            }
        }

        public class AssignorMessage : AssignorParent
        {
            string _text;

            public string Text
            {
                get { return _text; }
                set { _text = value; }
            }

            DateTime _registrationDate;

            public DateTime RegistrationDate
            {
                get { return _registrationDate; }
                set { _registrationDate = value; }
            }

            AssignorUser _user;

            public AssignorUser User
            {
                get { return _user; }
            }

            int? _senderID;

            public int? SenderID
            {
                get { return _senderID; }
                set
                {
                    _senderID = value;
                    if (_senderID != null)
                    {
                        ModelContainer ml = new ModelContainer();
                        _user = PublicFunctions.MakeAssignor<User, AssignorUser>(ml.Users.Where(t => t.ID == _senderID).First());
                    }
                }
            }

            string _email;

            public string Email
            {
                get { return _email; }
                set { _email = value; }
            }
        }
       
        public class AssignorComment : AssignorMessage
        {

            private AssignorAdvertisment _adv;

            public AssignorAdvertisment Adv
            {
                get { return _adv; }
            }
            
            private int _advID;

            public int AdvID
            {
                get { return _advID; }
                set { _advID = value;
                ModelContainer ml = new ModelContainer();
                _adv = PublicFunctions.MakeAssignor<Advertisment, AssignorAdvertisment>(ml.Advertisments.Where(t => t.ID == _advID).First());
                }
            }

            private bool _isConfirmed;

            public bool IsConfirmed
            {
                get { return _isConfirmed; }
                set { _isConfirmed = value; }
            }

        }

        public class AssignorUserMessage {

            private AssignorUser _user;

            public AssignorUser User
            {
                get { return _user; }
            }
            
            private int _recieverID;

            public int RecieverID
            {
                get { return _recieverID; }
                set { _recieverID = value;
                ModelContainer ml = new ModelContainer();
                _user = PublicFunctions.MakeAssignor<User, AssignorUser>(ml.Users.Where(t => t.ID == _recieverID).First());
                }
            }
          

        }

        
}       

