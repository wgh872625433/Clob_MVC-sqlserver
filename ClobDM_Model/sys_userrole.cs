using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace ClobDM_Model.Model{
	 	//sys_userrole
		public class sys_userrole
	{
   		     
      	/// <summary>
		/// ID
        /// </summary>		
		private int _id;
        public int ID
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// SU_UID
        /// </summary>		
		private int _su_uid;
        public int SU_UID
        {
            get{ return _su_uid; }
            set{ _su_uid = value; }
        }        
		/// <summary>
		/// SU_RID
        /// </summary>		
		private int _su_rid;
        public int SU_RID
        {
            get{ return _su_rid; }
            set{ _su_rid = value; }
        }        
		/// <summary>
		/// SU_sort
        /// </summary>		
		private int _su_sort;
        public int SU_sort
        {
            get{ return _su_sort; }
            set{ _su_sort = value; }
        }        
		/// <summary>
		/// SU_state
        /// </summary>		
		private int _su_state;
        public int SU_state
        {
            get{ return _su_state; }
            set{ _su_state = value; }
        }        
		/// <summary>
		/// CreateTime
        /// </summary>		
		private DateTime _createtime;
        public DateTime CreateTime
        {
            get{ return _createtime; }
            set{ _createtime = value; }
        }        
		/// <summary>
		/// CreateUser
        /// </summary>		
		private int _createuser;
        public int CreateUser
        {
            get{ return _createuser; }
            set{ _createuser = value; }
        }        
		/// <summary>
		/// UpdateTime
        /// </summary>		
		private DateTime _updatetime;
        public DateTime UpdateTime
        {
            get{ return _updatetime; }
            set{ _updatetime = value; }
        }        
		/// <summary>
		/// UpdateUser
        /// </summary>		
		private int _updateuser;
        public int UpdateUser
        {
            get{ return _updateuser; }
            set{ _updateuser = value; }
        }        
		   
	}
}

