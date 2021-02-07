using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace ClobDM_Model.Model{
	 	//sys_roleInMenuTest
		public class sys_roleInMenuTest
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
		/// S_RID
        /// </summary>		
		private int _s_rid;
        public int S_RID
        {
            get{ return _s_rid; }
            set{ _s_rid = value; }
        }        
		/// <summary>
		/// S_Mids
        /// </summary>		
		private string _s_mids;
        public string S_Mids
        {
            get{ return _s_mids; }
            set{ _s_mids = value; }
        }        
		/// <summary>
		/// S_state
        /// </summary>		
		private int _s_state;
        public int S_state
        {
            get{ return _s_state; }
            set{ _s_state = value; }
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

