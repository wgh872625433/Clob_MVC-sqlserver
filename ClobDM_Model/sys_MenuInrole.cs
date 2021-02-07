using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace ClobDM_Model.Model{
	 	//sys_MenuInrole
		public class sys_MenuInrole
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
		/// s_roleId
        /// </summary>		
		private int _s_roleid;
        public int s_roleId
        {
            get{ return _s_roleid; }
            set{ _s_roleid = value; }
        }        
		/// <summary>
		/// s_MenuId
        /// </summary>		
		private int _s_menuid;
        public int s_MenuId
        {
            get{ return _s_menuid; }
            set{ _s_menuid = value; }
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

