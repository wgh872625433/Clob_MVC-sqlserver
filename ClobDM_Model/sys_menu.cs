using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace ClobDM_Model.Model{
	 	//sys_menu
		public class sys_menu
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
		/// M_Name
        /// </summary>		
		private string _m_name;
        public string M_Name
        {
            get{ return _m_name; }
            set{ _m_name = value; }
        }        
		/// <summary>
		/// M_PID
        /// </summary>		
		private int _m_pid;
        public int M_PID
        {
            get{ return _m_pid; }
            set{ _m_pid = value; }
        }        
		/// <summary>
		/// M_Url
        /// </summary>		
		private string _m_url;
        public string M_Url
        {
            get{ return _m_url; }
            set{ _m_url = value; }
        }        
		/// <summary>
		/// M_code
        /// </summary>		
		private string _m_code;
        public string M_code
        {
            get{ return _m_code; }
            set{ _m_code = value; }
        }        
		/// <summary>
		/// M_sort
        /// </summary>		
		private int _m_sort;
        public int M_sort
        {
            get{ return _m_sort; }
            set{ _m_sort = value; }
        }        
		/// <summary>
		/// M_State
        /// </summary>		
		private int _m_state;
        public int M_State
        {
            get{ return _m_state; }
            set{ _m_state = value; }
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

