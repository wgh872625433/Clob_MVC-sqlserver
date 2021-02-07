using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Clob.Model{
	 	//sys_menuoperate
		public class sys_menuoperate
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
		/// MO_Name
        /// </summary>		
		private string _mo_name;
        public string MO_Name
        {
            get{ return _mo_name; }
            set{ _mo_name = value; }
        }        
		/// <summary>
		/// MO_Type
        /// </summary>		
		private int _mo_type;
        public int MO_Type
        {
            get{ return _mo_type; }
            set{ _mo_type = value; }
        }        
		/// <summary>
		/// MO_Srot
        /// </summary>		
		private int _mo_srot;
        public int MO_Srot
        {
            get{ return _mo_srot; }
            set{ _mo_srot = value; }
        }        
		/// <summary>
		/// MO_State
        /// </summary>		
		private int _mo_state;
        public int MO_State
        {
            get{ return _mo_state; }
            set{ _mo_state = value; }
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
		/// <summary>
		/// MO_MID
        /// </summary>		
		private int _mo_mid;
        public int MO_MID
        {
            get{ return _mo_mid; }
            set{ _mo_mid = value; }
        }        
		   
	}
}

