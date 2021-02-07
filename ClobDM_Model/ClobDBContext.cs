using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ClobDM_Model.Model;
namespace ClobDM_Model
{
    public class ClobDBContext:DbContext
    {

        public ClobDBContext()
            : base("name=ClobDBContext")
        {
           
        }
        public DbSet<sys_userinfo> sys_userinfo { get; set; }

        public DbSet<sys_role> sys_role { get; set; }

        public DbSet<polyester_chip> polyester_chip { get; set; }
        public DbSet<Heat_shrinkf> Heat_shrinkf { get; set; }

        public DbSet<Acroleic_acid> Acroleic_acid { get; set; }

        public DbSet<Continue_Solid> Continue_Solid { get; set; }

        public DbSet<Pull_Film> Pull_Film { get; set; }

        public DbSet<PaperBox_check> PaperBox_check { get; set; }
        public DbSet<Water_solid> Water_solid { get; set; }

        public DbSet<Starch_check> Starch_check { get; set; }

        public DbSet<coal_check> coal_check { get; set; }

        public DbSet<Custome_Stand> Custome_Stand { get; set; }
        public DbSet<Stattis_day> Stattis_day { get; set; }

        public DbSet<Stattis_Hot> Stattis_Hot { get; set; }

        public DbSet<Stattis_Kg> Stattis_Kg { get; set; }

        public DbSet<Stattis_Solid> Stattis_Solid { get; set; }

    }

    #region 用户相关实体
    public class sys_userinfo
    {

        /// <summary>
        /// ID
        /// </summary>		
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// S_username
        /// </summary>		
        private string _s_username;
        public string S_username
        {
            get { return _s_username; }
            set { _s_username = value; }
        }
        /// <summary>
        /// S_realName
        /// </summary>		
        private string _s_realname;
        public string S_realName
        {
            get { return _s_realname; }
            set { _s_realname = value; }
        }
        /// <summary>
        /// S_password
        /// </summary>		
        private string _s_password;
        public string S_password
        {
            get { return _s_password; }
            set { _s_password = value; }
        }
        /// <summary>
        /// S_checkUID
        /// </summary>		
        private int _s_checkuid;
        public int S_checkUID
        {
            get { return _s_checkuid; }
            set { _s_checkuid = value; }
        }
        /// <summary>
        /// S_roleId
        /// </summary>		
        private int _s_roleid;
        public int S_roleId
        {
            get { return _s_roleid; }
            set { _s_roleid = value; }
        }
        /// <summary>
        /// S_state
        /// </summary>		
        private int _s_state;
        public int S_state
        {
            get { return _s_state; }
            set { _s_state = value; }
        }
        /// <summary>
        /// CreateTime
        /// </summary>		
        private DateTime _createtime;
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        /// <summary>
        /// CreateUser
        /// </summary>		
        private int _createuser;
        public int CreateUser
        {
            get { return _createuser; }
            set { _createuser = value; }
        }
        /// <summary>
        /// UpdateTime
        /// </summary>		
        private DateTime _updatetime;
        public DateTime UpdateTime
        {
            get { return _updatetime; }
            set { _updatetime = value; }
        }
        /// <summary>
        /// UpdateUser
        /// </summary>		
        private int _updateuser;
        public int UpdateUser
        {
            get { return _updateuser; }
            set { _updateuser = value; }
        }

    }


    public class sys_role
    {

        /// <summary>
        /// ID
        /// </summary>		
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// S_name
        /// </summary>		
        private string _s_name;
        public string S_name
        {
            get { return _s_name; }
            set { _s_name = value; }
        }
        /// <summary>
        /// S_sort
        /// </summary>		
        private int _s_sort;
        public int S_sort
        {
            get { return _s_sort; }
            set { _s_sort = value; }
        }
        /// <summary>
        /// S_state
        /// </summary>		
        private int _s_state;
        public int S_state
        {
            get { return _s_state; }
            set { _s_state = value; }
        }
        /// <summary>
        /// CreateTime
        /// </summary>		
        private DateTime _createtime;
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        /// <summary>
        /// CreateUser
        /// </summary>		
        private int _createuser;
        public int CreateUser
        {
            get { return _createuser; }
            set { _createuser = value; }
        }
        /// <summary>
        /// UpdateTime
        /// </summary>		
        private DateTime _updatetime;
        public DateTime UpdateTime
        {
            get { return _updatetime; }
            set { _updatetime = value; }
        }
        /// <summary>
        /// UpdateUser
        /// </summary>		
        private int _updateuser;
        public int UpdateUser
        {
            get { return _updateuser; }
            set { _updateuser = value; }
        }

    }



    public class Custome_Stand
    {

        /// <summary>
        /// ID
        /// </summary>		
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// CS_Name
        /// </summary>		
        private string _cs_name;
        public string CS_Name
        {
            get { return _cs_name; }
            set { _cs_name = value; }
        }
        /// <summary>
        /// CS_Deep
        /// </summary>		
        private decimal _cs_deep;
        public decimal CS_Deep
        {
            get { return _cs_deep; }
            set { _cs_deep = value; }
        }
        /// <summary>
        /// CS_DeepS
        /// </summary>		
        private decimal _cs_deeps;
        public decimal CS_DeepS
        {
            get { return _cs_deeps; }
            set { _cs_deeps = value; }
        }
        /// <summary>
        /// CS_BreakPowerS1
        /// </summary>		
        private int _cs_breakpowers1;
        public int CS_BreakPowerS1
        {
            get { return _cs_breakpowers1; }
            set { _cs_breakpowers1 = value; }
        }
        /// <summary>
        /// CS_BreakPowerS2
        /// </summary>		
        private int _cs_breakpowers2;
        public int CS_BreakPowerS2
        {
            get { return _cs_breakpowers2; }
            set { _cs_breakpowers2 = value; }
        }
        /// <summary>
        /// CS_BreakPowerS3
        /// </summary>		
        private int _cs_breakpowers3;
        public int CS_BreakPowerS3
        {
            get { return _cs_breakpowers3; }
            set { _cs_breakpowers3 = value; }
        }
        /// <summary>
        /// CS_deformation_rate1
        /// </summary>		
        private int _cs_deformation_rate1;
        public int CS_deformation_rate1
        {
            get { return _cs_deformation_rate1; }
            set { _cs_deformation_rate1 = value; }
        }
        /// <summary>
        /// CS_deformation_rate2
        /// </summary>		
        private int _cs_deformation_rate2;
        public int CS_deformation_rate2
        {
            get { return _cs_deformation_rate2; }
            set { _cs_deformation_rate2 = value; }
        }
        /// <summary>
        /// CS_deformation_rate3
        /// </summary>		
        private int _cs_deformation_rate3;
        public int CS_deformation_rate3
        {
            get { return _cs_deformation_rate3; }
            set { _cs_deformation_rate3 = value; }
        }
        /// <summary>
        /// CreateTime
        /// </summary>		
        private DateTime _createtime;
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        /// <summary>
        /// CreateUser
        /// </summary>		
        private int _createuser;
        public int CreateUser
        {
            get { return _createuser; }
            set { _createuser = value; }
        }
        /// <summary>
        /// UpdateTime
        /// </summary>		
        private DateTime _updatetime;
        public DateTime UpdateTime
        {
            get { return _updatetime; }
            set { _updatetime = value; }
        }
        /// <summary>
        /// UpdateUser
        /// </summary>		
        private int _updateuser;
        public int UpdateUser
        {
            get { return _updateuser; }
            set { _updateuser = value; }
        }

    }

    #endregion 

    #region 实验室实体类

    public class polyester_chip
    {

        /// <summary>
        /// ID
        /// </summary>		
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// PC_ChekTime
        /// </summary>		
        private DateTime _pc_chektime;
        public DateTime PC_ChekTime
        {
            get { return _pc_chektime; }
            set { _pc_chektime = value; }
        }
        /// <summary>
        /// PC_InGoodsNum
        /// </summary>		
        private int _pc_ingoodsnum;
        public int PC_InGoodsNum
        {
            get { return _pc_ingoodsnum; }
            set { _pc_ingoodsnum = value; }
        }
        /// <summary>
        /// PC_WetSectionH
        /// </summary>		
        private decimal _pc_wetsectionh;
        public decimal PC_WetSectionH
        {
            get { return _pc_wetsectionh; }
            set { _pc_wetsectionh = value; }
        }
        /// <summary>
        /// PC_H1
        /// </summary>		
        private decimal _pc_h1;
        public decimal PC_H1
        {
            get { return _pc_h1; }
            set { _pc_h1 = value; }
        }
        /// <summary>
        /// PC_H2
        /// </summary>		
        private decimal _pc_h2;
        public decimal PC_H2
        {
            get { return _pc_h2; }
            set { _pc_h2 = value; }
        }
        /// <summary>
        /// PC_WaterCompent
        /// </summary>		
        private decimal _pc_watercompent;
        public decimal PC_WaterCompent
        {
            get { return _pc_watercompent; }
            set { _pc_watercompent = value; }
        }
        /// <summary>
        /// PC_FCheckWater
        /// </summary>		
        private decimal _pc_fcheckwater;
        public decimal PC_FCheckWater
        {
            get { return _pc_fcheckwater; }
            set { _pc_fcheckwater = value; }
        }
        /// <summary>
        /// PC_FCheckSS
        /// </summary>		
        private decimal _pc_fcheckss;
        public decimal PC_FCheckSS
        {
            get { return _pc_fcheckss; }
            set { _pc_fcheckss = value; }
        }
        /// <summary>
        /// PC_HundredW1
        /// </summary>		
        private decimal _pc_hundredw1;
        public decimal PC_HundredW1
        {
            get { return _pc_hundredw1; }
            set { _pc_hundredw1 = value; }
        }
        /// <summary>
        /// PC_HundredW2
        /// </summary>		
        private decimal _pc_hundredw2;
        public decimal PC_HundredW2
        {
            get { return _pc_hundredw2; }
            set { _pc_hundredw2 = value; }
        }
        /// <summary>
        /// PC_CheckUser
        /// </summary>		
        private string _pc_checkuser;
        public string PC_CheckUser
        {
            get { return _pc_checkuser; }
            set { _pc_checkuser = value; }
        }
        /// <summary>
        /// PC_FName
        /// </summary>		
        private string _pc_fname;
        public string PC_FName
        {
            get { return _pc_fname; }
            set { _pc_fname = value; }
        }
        /// <summary>
        /// PC_PCode
        /// </summary>		
        private string _pc_pcode;
        public string PC_PCode
        {
            get { return _pc_pcode; }
            set { _pc_pcode = value; }
        }
        /// <summary>
        /// PC_HeapUPD
        /// </summary>		
        private string _pc_heapupd;
        public string PC_HeapUPD
        {
            get { return _pc_heapupd; }
            set { _pc_heapupd = value; }
        }
        /// <summary>
        /// PC_MeltingP
        /// </summary>		
        private int _pc_meltingp;
        public int PC_MeltingP
        {
            get { return _pc_meltingp; }
            set { _pc_meltingp = value; }
        }
        /// <summary>
        /// PC_Remark
        /// </summary>		
        private string _pc_remark;
        public string PC_Remark
        {
            get { return _pc_remark; }
            set { _pc_remark = value; }
        }
        /// <summary>
        /// PC_PassMsg
        /// </summary>		
        private string _pc_passmsg;
        public string PC_PassMsg
        {
            get { return _pc_passmsg; }
            set { _pc_passmsg = value; }
        }
        /// <summary>
        /// CreateTime
        /// </summary>		
        private DateTime _createtime;
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        /// <summary>
        /// CreateUser
        /// </summary>		
        private int _createuser;
        public int CreateUser
        {
            get { return _createuser; }
            set { _createuser = value; }
        }
        /// <summary>
        /// UpdateTime
        /// </summary>	
        private DateTime _updatetime;
        public DateTime UpdateTime
        {
            get { return _updatetime; }
            set { _updatetime = value; }
        }
        /// <summary>
        /// UpdateUser
        /// </summary>		
        private int _updateuser;
        public int UpdateUser
        {
            get { return _updateuser; }
            set { _updateuser = value; }
        }

    }


    public class Heat_shrinkf
    {

        /// <summary>
        /// ID
        /// </summary>		
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// HS_InTime
        /// </summary>		
        private DateTime _hs_intime;
        public DateTime HS_InTime
        {
            get { return _hs_intime; }
            set { _hs_intime = value; }
        }
        /// <summary>
        /// HS_InGoodsNum
        /// </summary>		
        private int _hs_ingoodsnum;
        public int HS_InGoodsNum
        {
            get { return _hs_ingoodsnum; }
            set { _hs_ingoodsnum = value; }
        }
        /// <summary>
        /// HS_Pstandard
        /// </summary>		
        private string _hs_pstandard;
        public string HS_Pstandard
        {
            get { return _hs_pstandard; }
            set { _hs_pstandard = value; }
        }
        /// <summary>
        /// HS_gm
        /// </summary>		
        private decimal _hs_gm;
        public decimal HS_gm
        {
            get { return _hs_gm; }
            set { _hs_gm = value; }
        }
        /// <summary>
        /// HS_mm
        /// </summary>		
        private decimal _hs_mm;
        public decimal HS_mm
        {
            get { return _hs_mm; }
            set { _hs_mm = value; }
        }
        /// <summary>
        /// HS_ww
        /// </summary>		
        private int _hs_ww;
        public int HS_ww
        {
            get { return _hs_ww; }
            set { _hs_ww = value; }
        }
        /// <summary>
        /// HS_drawSMD
        /// </summary>		
        private decimal _hs_drawsmd;
        public decimal HS_drawSMD
        {
            get { return _hs_drawsmd; }
            set { _hs_drawsmd = value; }
        }
        /// <summary>
        /// HS_drawSMC
        /// </summary>		
        private decimal _hs_drawsmc;
        public decimal HS_drawSMC
        {
            get { return _hs_drawsmc; }
            set { _hs_drawsmc = value; }
        }
        /// <summary>
        /// HS_disruptED
        /// </summary>		
        private decimal _hs_disrupted;
        public decimal HS_disruptED
        {
            get { return _hs_disrupted; }
            set { _hs_disrupted = value; }
        }
        /// <summary>
        /// HS_disruptEC
        /// </summary>		
        private decimal _hs_disruptec;
        public decimal HS_disruptEC
        {
            get { return _hs_disruptec; }
            set { _hs_disruptec = value; }
        }
        /// <summary>
        /// HS_Fmm
        /// </summary>		
        private decimal _hs_fmm;
        public decimal HS_Fmm
        {
            get { return _hs_fmm; }
            set { _hs_fmm = value; }
        }
        /// <summary>
        /// HS_Fww
        /// </summary>		
        private int _hs_fww;
        public int HS_Fww
        {
            get { return _hs_fww; }
            set { _hs_fww = value; }
        }
        /// <summary>
        /// HS_FdrawSMD
        /// </summary>		
        private decimal _hs_fdrawsmd;
        public decimal HS_FdrawSMD
        {
            get { return _hs_fdrawsmd; }
            set { _hs_fdrawsmd = value; }
        }
        /// <summary>
        /// HS_FdrawSMC
        /// </summary>		
        private decimal _hs_fdrawsmc;
        public decimal HS_FdrawSMC
        {
            get { return _hs_fdrawsmc; }
            set { _hs_fdrawsmc = value; }
        }
        /// <summary>
        /// HS_FdisruptED
        /// </summary>		
        private decimal _hs_fdisrupted;
        public decimal HS_FdisruptED
        {
            get { return _hs_fdisrupted; }
            set { _hs_fdisrupted = value; }
        }
        /// <summary>
        /// HS_FdisruptEC
        /// </summary>		
        private decimal _hs_fdisruptec;
        public decimal HS_FdisruptEC
        {
            get { return _hs_fdisruptec; }
            set { _hs_fdisruptec = value; }
        }
        /// <summary>
        /// HS_FColor
        /// </summary>		
        private string _hs_fcolor;
        public string HS_FColor
        {
            get { return _hs_fcolor; }
            set { _hs_fcolor = value; }
        }
        /// <summary>
        /// HS_FAddTime
        /// </summary>		
        private DateTime _hs_faddtime;
        public DateTime HS_FAddTime
        {
            get { return _hs_faddtime; }
            set { _hs_faddtime = value; }
        }
        /// <summary>
        /// HS_FName
        /// </summary>		
        private string _hs_fname;
        public string HS_FName
        {
            get { return _hs_fname; }
            set { _hs_fname = value; }
        }
        /// <summary>
        /// HS_FIsPass
        /// </summary>		
        private string _hs_fispass;
        public string HS_FIsPass
        {
            get { return _hs_fispass; }
            set { _hs_fispass = value; }
        }
        /// <summary>
        /// HS_FRemark
        /// </summary>		
        private string _hs_fremark;
        public string HS_FRemark
        {
            get { return _hs_fremark; }
            set { _hs_fremark = value; }
        }
        /// <summary>
        /// CreateTime
        /// </summary>		
        private DateTime _createtime;
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        /// <summary>
        /// CreateUser
        /// </summary>		
        private int _createuser;
        public int CreateUser
        {
            get { return _createuser; }
            set { _createuser = value; }
        }
        /// <summary>
        /// UpdateTime
        /// </summary>		
        private DateTime _updatetime;
        public DateTime UpdateTime
        {
            get { return _updatetime; }
            set { _updatetime = value; }
        }
        /// <summary>
        /// UpdateUser
        /// </summary>		
        private int _updateuser;
        public int UpdateUser
        {
            get { return _updateuser; }
            set { _updateuser = value; }
        }

    }

    public class Acroleic_acid
    {

        /// <summary>
        /// ID
        /// </summary>		
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// AA_CheckTime
        /// </summary>		
        private DateTime _aa_checktime;
        public DateTime AA_CheckTime
        {
            get { return _aa_checktime; }
            set { _aa_checktime = value; }
        }
        /// <summary>
        /// AA_InGoodNums
        /// </summary>		
        private int _aa_ingoodnums;
        public int AA_InGoodNums
        {
            get { return _aa_ingoodnums; }
            set { _aa_ingoodnums = value; }
        }
        /// <summary>
        /// AA_CheckGoodNums
        /// </summary>		
        private int _aa_checkgoodnums;
        public int AA_CheckGoodNums
        {
            get { return _aa_checkgoodnums; }
            set { _aa_checkgoodnums = value; }
        }
        /// <summary>
        /// AA_CrucibleW
        /// </summary>		
        private decimal _aa_cruciblew;
        public decimal AA_CrucibleW
        {
            get { return _aa_cruciblew; }
            set { _aa_cruciblew = value; }
        }
        /// <summary>
        /// AA_ArchFTW1
        /// </summary>		
        private decimal _aa_archftw1;
        public decimal AA_ArchFTW1
        {
            get { return _aa_archftw1; }
            set { _aa_archftw1 = value; }
        }
        /// <summary>
        /// AA_ArchFTW2
        /// </summary>		
        private decimal _aa_archftw2;
        public decimal AA_ArchFTW2
        {
            get { return _aa_archftw2; }
            set { _aa_archftw2 = value; }
        }
        /// <summary>
        /// AA_solid
        /// </summary>		
        private decimal _aa_solid;
        public decimal AA_solid
        {
            get { return _aa_solid; }
            set { _aa_solid = value; }
        }
        /// <summary>
        /// AA_avg
        /// </summary>		
        private decimal _aa_avg;
        public decimal AA_avg
        {
            get { return _aa_avg; }
            set { _aa_avg = value; }
        }
        /// <summary>
        /// AA_PH
        /// </summary>		
        private int _aa_ph;
        public int AA_PH
        {
            get { return _aa_ph; }
            set { _aa_ph = value; }
        }
        /// <summary>
        /// AA_Fsolid
        /// </summary>		
        private decimal _aa_fsolid;
        public decimal AA_Fsolid
        {
            get { return _aa_fsolid; }
            set { _aa_fsolid = value; }
        }
        /// <summary>
        /// AA_FPH
        /// </summary>		
        private int _aa_fph;
        public int AA_FPH
        {
            get { return _aa_fph; }
            set { _aa_fph = value; }
        }
        /// <summary>
        /// AA_AddTime
        /// </summary>		
        private DateTime _aa_addtime;
        public DateTime AA_AddTime
        {
            get { return _aa_addtime; }
            set { _aa_addtime = value; }
        }
        /// <summary>
        /// AA_FName
        /// </summary>		
        private string _aa_fname;
        public string AA_FName
        {
            get { return _aa_fname; }
            set { _aa_fname = value; }
        }
        /// <summary>
        /// AA_FIsPass
        /// </summary>		
        private string _aa_fispass;
        public string AA_FIsPass
        {
            get { return _aa_fispass; }
            set { _aa_fispass = value; }
        }
        /// <summary>
        /// AA_FCheckUID
        /// </summary>		
        private string _aa_fcheckuid;
        public string AA_FCheckUID
        {
            get { return _aa_fcheckuid; }
            set { _aa_fcheckuid = value; }
        }
        /// <summary>
        /// AA_FPassMsg
        /// </summary>		
        private string _aa_fpassmsg;
        public string AA_FPassMsg
        {
            get { return _aa_fpassmsg; }
            set { _aa_fpassmsg = value; }
        }
        /// <summary>
        /// AA_FRemark
        /// </summary>		
        private string _aa_fremark;
        public string AA_FRemark
        {
            get { return _aa_fremark; }
            set { _aa_fremark = value; }
        }
        /// <summary>
        /// CreateTime
        /// </summary>		
        private DateTime _createtime;
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        /// <summary>
        /// CreateUser
        /// </summary>		
        private int _createuser;
        public int CreateUser
        {
            get { return _createuser; }
            set { _createuser = value; }
        }
        /// <summary>
        /// UpdateTime
        /// </summary>		
        private DateTime _updatetime;
        public DateTime UpdateTime
        {
            get { return _updatetime; }
            set { _updatetime = value; }
        }
        /// <summary>
        /// UpdateUser
        /// </summary>		
        private int _updateuser;
        public int UpdateUser
        {
            get { return _updateuser; }
            set { _updateuser = value; }
        }

    }

    public class Continue_Solid
    {

        /// <summary>
        /// ID
        /// </summary>		
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// CS_CheckTime
        /// </summary>		
        private DateTime _cs_checktime;
        public DateTime CS_CheckTime
        {
            get { return _cs_checktime; }
            set { _cs_checktime = value; }
        }
        /// <summary>
        /// CS_InGoodNums
        /// </summary>		
        private int _cs_ingoodnums;
        public int CS_InGoodNums
        {
            get { return _cs_ingoodnums; }
            set { _cs_ingoodnums = value; }
        }
        /// <summary>
        /// CS_CheckGoodNums
        /// </summary>		
        private int _cs_checkgoodnums;
        public int CS_CheckGoodNums
        {
            get { return _cs_checkgoodnums; }
            set { _cs_checkgoodnums = value; }
        }
        /// <summary>
        /// CS_CrucibleW
        /// </summary>		
        private decimal _cs_cruciblew;
        public decimal CS_CrucibleW
        {
            get { return _cs_cruciblew; }
            set { _cs_cruciblew = value; }
        }
        /// <summary>
        /// CS_ArchFTW1
        /// </summary>		
        private decimal _cs_archftw1;
        public decimal CS_ArchFTW1
        {
            get { return _cs_archftw1; }
            set { _cs_archftw1 = value; }
        }
        /// <summary>
        /// CS_ArchFTW2
        /// </summary>		
        private decimal _cs_archftw2;
        public decimal CS_ArchFTW2
        {
            get { return _cs_archftw2; }
            set { _cs_archftw2 = value; }
        }
        /// <summary>
        /// CS_solid
        /// </summary>		
        private decimal _cs_solid;
        public decimal CS_solid
        {
            get { return _cs_solid; }
            set { _cs_solid = value; }
        }
        /// <summary>
        /// CS_avg
        /// </summary>		
        private decimal _cs_avg;
        public decimal CS_avg
        {
            get { return _cs_avg; }
            set { _cs_avg = value; }
        }
        /// <summary>
        /// CS_PH
        /// </summary>		
        private decimal _cs_ph;
        public decimal CS_PH
        {
            get { return _cs_ph; }
            set { _cs_ph = value; }
        }
        /// <summary>
        /// CS_Fsolid
        /// </summary>		
        private decimal _cs_fsolid;
        public decimal CS_Fsolid
        {
            get { return _cs_fsolid; }
            set { _cs_fsolid = value; }
        }
        /// <summary>
        /// CS_FPH
        /// </summary>		
        private decimal _cs_fph;
        public decimal CS_FPH
        {
            get { return _cs_fph; }
            set { _cs_fph = value; }
        }
        /// <summary>
        /// CS_name
        /// </summary>		
        private string _cs_name;
        public string CS_name
        {
            get { return _cs_name; }
            set { _cs_name = value; }
        }
        /// <summary>
        /// CS_addTime
        /// </summary>		
        private DateTime _cs_addtime;
        public DateTime CS_addTime
        {
            get { return _cs_addtime; }
            set { _cs_addtime = value; }
        }
        /// <summary>
        /// CS_IsPass
        /// </summary>		
        private string _cs_ispass;
        public string CS_IsPass
        {
            get { return _cs_ispass; }
            set { _cs_ispass = value; }
        }
        /// <summary>
        /// CS_Remark
        /// </summary>		
        private string _cs_remark;
        public string CS_Remark
        {
            get { return _cs_remark; }
            set { _cs_remark = value; }
        }
        /// <summary>
        /// CS_CheckUID
        /// </summary>		
        private string _cs_checkuid;
        public string CS_CheckUID
        {
            get { return _cs_checkuid; }
            set { _cs_checkuid = value; }
        }
        /// <summary>
        /// CS_IsPassMsg
        /// </summary>		
        private string _cs_ispassmsg;
        public string CS_IsPassMsg
        {
            get { return _cs_ispassmsg; }
            set { _cs_ispassmsg = value; }
        }
        /// <summary>
        /// CreateTime
        /// </summary>		
        private DateTime _createtime;
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        /// <summary>
        /// CreateUser
        /// </summary>		
        private int _createuser;
        public int CreateUser
        {
            get { return _createuser; }
            set { _createuser = value; }
        }
        /// <summary>
        /// UpdateTime
        /// </summary>		
        private DateTime _updatetime;
        public DateTime UpdateTime
        {
            get { return _updatetime; }
            set { _updatetime = value; }
        }
        /// <summary>
        /// UpdateUser
        /// </summary>		
        private int _updateuser;
        public int UpdateUser
        {
            get { return _updateuser; }
            set { _updateuser = value; }
        }

    }


    public class Pull_Film
    {

        /// <summary>
        /// ID
        /// </summary>		
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// PF_InGoodsTime
        /// </summary>		
        private DateTime _pf_ingoodstime;
        public DateTime PF_InGoodsTime
        {
            get { return _pf_ingoodstime; }
            set { _pf_ingoodstime = value; }
        }
        /// <summary>
        /// PF_Stand
        /// </summary>		
        private string _pf_stand;
        public string PF_Stand
        {
            get { return _pf_stand; }
            set { _pf_stand = value; }
        }
        /// <summary>
        /// PF_FcleanW
        /// </summary>		
        private decimal _pf_fcleanw;
        public decimal PF_FcleanW
        {
            get { return _pf_fcleanw; }
            set { _pf_fcleanw = value; }
        }
        /// <summary>
        /// PF_Fmm
        /// </summary>		
        private decimal _pf_fmm;
        public decimal PF_Fmm
        {
            get { return _pf_fmm; }
            set { _pf_fmm = value; }
        }
        /// <summary>
        /// PF_Fww
        /// </summary>		
        private int _pf_fww;
        public int PF_Fww
        {
            get { return _pf_fww; }
            set { _pf_fww = value; }
        }
        /// <summary>
        /// PF_FdrawSM1
        /// </summary>		
        private int _pf_fdrawsm1;
        public int PF_FdrawSM1
        {
            get { return _pf_fdrawsm1; }
            set { _pf_fdrawsm1 = value; }
        }
        /// <summary>
        /// PF_FdrawSM2
        /// </summary>		
        private decimal _pf_fdrawsm2;
        public decimal PF_FdrawSM2
        {
            get { return _pf_fdrawsm2; }
            set { _pf_fdrawsm2 = value; }
        }
        /// <summary>
        /// PF_FdisruptED
        /// </summary>		
        private int _pf_fdisrupted;
        public int PF_FdisruptED
        {
            get { return _pf_fdisrupted; }
            set { _pf_fdisrupted = value; }
        }
        /// <summary>
        /// PF_FchargeS
        /// </summary>		
        private int _pf_fcharges;
        public int PF_FchargeS
        {
            get { return _pf_fcharges; }
            set { _pf_fcharges = value; }
        }
        /// <summary>
        /// PF_Fsticky
        /// </summary>		
        private string _pf_fsticky;
        public string PF_Fsticky
        {
            get { return _pf_fsticky; }
            set { _pf_fsticky = value; }
        }
        /// <summary>
        /// PF_FName
        /// </summary>		
        private string _pf_fname;
        public string PF_FName
        {
            get { return _pf_fname; }
            set { _pf_fname = value; }
        }
        /// <summary>
        /// PF_TWeight
        /// </summary>		
        private decimal _pf_tweight;
        public decimal PF_TWeight
        {
            get { return _pf_tweight; }
            set { _pf_tweight = value; }
        }
        /// <summary>
        /// PF_PBox
        /// </summary>		
        private decimal _pf_pbox;
        public decimal PF_PBox
        {
            get { return _pf_pbox; }
            set { _pf_pbox = value; }
        }
        /// <summary>
        /// PF_PChannel
        /// </summary>		
        private decimal _pf_pchannel;
        public decimal PF_PChannel
        {
            get { return _pf_pchannel; }
            set { _pf_pchannel = value; }
        }
        /// <summary>
        /// PF_CleanW
        /// </summary>		
        private decimal _pf_cleanw;
        public decimal PF_CleanW
        {
            get { return _pf_cleanw; }
            set { _pf_cleanw = value; }
        }
        /// <summary>
        /// PF_InGoodNums
        /// </summary>		
        private int _pf_ingoodnums;
        public int PF_InGoodNums
        {
            get { return _pf_ingoodnums; }
            set { _pf_ingoodnums = value; }
        }
        /// <summary>
        /// PF_CheckGoodNums
        /// </summary>		
        private int _pf_checkgoodnums;
        public int PF_CheckGoodNums
        {
            get { return _pf_checkgoodnums; }
            set { _pf_checkgoodnums = value; }
        }
        /// <summary>
        /// PF_gm
        /// </summary>		
        private decimal _pf_gm;
        public decimal PF_gm
        {
            get { return _pf_gm; }
            set { _pf_gm = value; }
        }
        /// <summary>
        /// PF_ww
        /// </summary>		
        private decimal _pf_ww;
        public decimal PF_ww
        {
            get { return _pf_ww; }
            set { _pf_ww = value; }
        }
        /// <summary>
        /// PF_mm
        /// </summary>		
        private decimal _pf_mm;
        public decimal PF_mm
        {
            get { return _pf_mm; }
            set { _pf_mm = value; }
        }
        /// <summary>
        /// PF_PowerW1
        /// </summary>		
        private decimal _pf_powerw1;
        public decimal PF_PowerW1
        {
            get { return _pf_powerw1; }
            set { _pf_powerw1 = value; }
        }
        /// <summary>
        /// PF_PowerW2
        /// </summary>		
        private decimal _pf_powerw2;
        public decimal PF_PowerW2
        {
            get { return _pf_powerw2; }
            set { _pf_powerw2 = value; }
        }
        /// <summary>
        /// PF_drawSM1
        /// </summary>		
        private int _pf_drawsm1;
        public int PF_drawSM1
        {
            get { return _pf_drawsm1; }
            set { _pf_drawsm1 = value; }
        }
        /// <summary>
        /// PF_drawSM2
        /// </summary>		
        private int _pf_drawsm2;
        public int PF_drawSM2
        {
            get { return _pf_drawsm2; }
            set { _pf_drawsm2 = value; }
        }
        /// <summary>
        /// PF_Remark
        /// </summary>		
        private string _pf_remark;
        public string PF_Remark
        {
            get { return _pf_remark; }
            set { _pf_remark = value; }
        }
        /// <summary>
        /// PF_CheckUID
        /// </summary>		
        private string _pf_checkuid;
        public string PF_CheckUID
        {
            get { return _pf_checkuid; }
            set { _pf_checkuid = value; }
        }
        /// <summary>
        /// CreateTime
        /// </summary>		
        private DateTime _createtime;
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        /// <summary>
        /// CreateUser
        /// </summary>		
        private int _createuser;
        public int CreateUser
        {
            get { return _createuser; }
            set { _createuser = value; }
        }
        /// <summary>
        /// UpdateTime
        /// </summary>		
        private DateTime _updatetime;
        public DateTime UpdateTime
        {
            get { return _updatetime; }
            set { _updatetime = value; }
        }
        /// <summary>
        /// UpdateUser
        /// </summary>		
        private int _updateuser;
        public int UpdateUser
        {
            get { return _updateuser; }
            set { _updateuser = value; }
        }

    }

    public class PaperBox_check
    {

        /// <summary>
        /// ID
        /// </summary>		
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// PBC_CheckTime
        /// </summary>		
        private DateTime _pbc_checktime;
        public DateTime PBC_CheckTime
        {
            get { return _pbc_checktime; }
            set { _pbc_checktime = value; }
        }
        /// <summary>
        /// PBC_Stand
        /// </summary>		
        private string _pbc_stand;
        public string PBC_Stand
        {
            get { return _pbc_stand; }
            set { _pbc_stand = value; }
        }
        /// <summary>
        /// PBC_mm
        /// </summary>		
        private string _pbc_mm;
        public string PBC_mm
        {
            get { return _pbc_mm; }
            set { _pbc_mm = value; }
        }
        /// <summary>
        /// PBC_mm1
        /// </summary>		
        private string _pbc_mm1;
        public string PBC_mm1
        {
            get { return _pbc_mm1; }
            set { _pbc_mm1 = value; }
        }
        /// <summary>
        /// PBC_mm2
        /// </summary>		
        private string _pbc_mm2;
        public string PBC_mm2
        {
            get { return _pbc_mm2; }
            set { _pbc_mm2 = value; }
        }
        /// <summary>
        /// PBC_PressAvg
        /// </summary>		
        private int _pbc_pressavg;
        public int PBC_PressAvg
        {
            get { return _pbc_pressavg; }
            set { _pbc_pressavg = value; }
        }
        /// <summary>
        /// PBC_PressMin
        /// </summary>		
        private int _pbc_pressmin;
        public int PBC_PressMin
        {
            get { return _pbc_pressmin; }
            set { _pbc_pressmin = value; }
        }
        /// <summary>
        /// PBC_PressMax
        /// </summary>		
        private int _pbc_pressmax;
        public int PBC_PressMax
        {
            get { return _pbc_pressmax; }
            set { _pbc_pressmax = value; }
        }
        /// <summary>
        /// PBC_Fmm
        /// </summary>		
        private decimal _pbc_fmm;
        public decimal PBC_Fmm
        {
            get { return _pbc_fmm; }
            set { _pbc_fmm = value; }
        }
        /// <summary>
        /// PBC_Fmm1
        /// </summary>		
        private decimal _pbc_fmm1;
        public decimal PBC_Fmm1
        {
            get { return _pbc_fmm1; }
            set { _pbc_fmm1 = value; }
        }
        /// <summary>
        /// PBC_Fmm2
        /// </summary>		
        private int _pbc_fmm2;
        public int PBC_Fmm2
        {
            get { return _pbc_fmm2; }
            set { _pbc_fmm2 = value; }
        }
        /// <summary>
        /// PBC_FPressP
        /// </summary>		
        private int _pbc_fpressp;
        public int PBC_FPressP
        {
            get { return _pbc_fpressp; }
            set { _pbc_fpressp = value; }
        }
        /// <summary>
        /// PBC_FInGoodNums
        /// </summary>		
        private int _pbc_fingoodnums;
        public int PBC_FInGoodNums
        {
            get { return _pbc_fingoodnums; }
            set { _pbc_fingoodnums = value; }
        }
        /// <summary>
        /// PBC_FCheckGoodNums
        /// </summary>		
        private int _pbc_fcheckgoodnums;
        public int PBC_FCheckGoodNums
        {
            get { return _pbc_fcheckgoodnums; }
            set { _pbc_fcheckgoodnums = value; }
        }
        /// <summary>
        /// PBC_FName
        /// </summary>		
        private string _pbc_fname;
        public string PBC_FName
        {
            get { return _pbc_fname; }
            set { _pbc_fname = value; }
        }
        /// <summary>
        /// PBC_FQualityMsg
        /// </summary>		
        private string _pbc_fqualitymsg;
        public string PBC_FQualityMsg
        {
            get { return _pbc_fqualitymsg; }
            set { _pbc_fqualitymsg = value; }
        }
        /// <summary>
        /// PBC_FCheckUID
        /// </summary>		
        private string _pbc_fcheckuid;
        public string PBC_FCheckUID
        {
            get { return _pbc_fcheckuid; }
            set { _pbc_fcheckuid = value; }
        }
        /// <summary>
        /// PBC_FRemark
        /// </summary>		
        private string _pbc_fremark;
        public string PBC_FRemark
        {
            get { return _pbc_fremark; }
            set { _pbc_fremark = value; }
        }
        /// <summary>
        /// PBC_FIsPassMsg
        /// </summary>		
        private string _pbc_fispassmsg;
        public string PBC_FIsPassMsg
        {
            get { return _pbc_fispassmsg; }
            set { _pbc_fispassmsg = value; }
        }
        /// <summary>
        /// CreateTime
        /// </summary>		
        private DateTime _createtime;
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        /// <summary>
        /// CreateUser
        /// </summary>		
        private int _createuser;
        public int CreateUser
        {
            get { return _createuser; }
            set { _createuser = value; }
        }
        /// <summary>
        /// UpdateTime
        /// </summary>		
        private DateTime _updatetime;
        public DateTime UpdateTime
        {
            get { return _updatetime; }
            set { _updatetime = value; }
        }
        /// <summary>
        /// UpdateUser
        /// </summary>		
        private int _updateuser;
        public int UpdateUser
        {
            get { return _updateuser; }
            set { _updateuser = value; }
        }

    }

    public class Water_solid
    {

        /// <summary>
        /// ID
        /// </summary>		
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// WS_CheckTime
        /// </summary>		
        private DateTime _ws_checktime;
        public DateTime WS_CheckTime
        {
            get { return _ws_checktime; }
            set { _ws_checktime = value; }
        }
        /// <summary>
        /// WS_InGoodNums
        /// </summary>		
        private int _ws_ingoodnums;
        public int WS_InGoodNums
        {
            get { return _ws_ingoodnums; }
            set { _ws_ingoodnums = value; }
        }
        /// <summary>
        /// WS_CheckGoodNums
        /// </summary>		
        private int _ws_checkgoodnums;
        public int WS_CheckGoodNums
        {
            get { return _ws_checkgoodnums; }
            set { _ws_checkgoodnums = value; }
        }
        /// <summary>
        /// WS_CrucibleW
        /// </summary>		
        private decimal _ws_cruciblew;
        public decimal WS_CrucibleW
        {
            get { return _ws_cruciblew; }
            set { _ws_cruciblew = value; }
        }
        /// <summary>
        /// WS_ArchFTW1
        /// </summary>		
        private decimal _ws_archftw1;
        public decimal WS_ArchFTW1
        {
            get { return _ws_archftw1; }
            set { _ws_archftw1 = value; }
        }
        /// <summary>
        /// WS_ArchFTW2
        /// </summary>		
        private decimal _ws_archftw2;
        public decimal WS_ArchFTW2
        {
            get { return _ws_archftw2; }
            set { _ws_archftw2 = value; }
        }
        /// <summary>
        /// WS_solid
        /// </summary>		
        private decimal _ws_solid;
        public decimal WS_solid
        {
            get { return _ws_solid; }
            set { _ws_solid = value; }
        }
        /// <summary>
        /// WS_avg
        /// </summary>		
        private decimal _ws_avg;
        public decimal WS_avg
        {
            get { return _ws_avg; }
            set { _ws_avg = value; }
        }
        /// <summary>
        /// WS_PH
        /// </summary>		
        private int _ws_ph;
        public int WS_PH
        {
            get { return _ws_ph; }
            set { _ws_ph = value; }
        }
        /// <summary>
        /// WS_Fsolid
        /// </summary>		
        private decimal _ws_fsolid;
        public decimal WS_Fsolid
        {
            get { return _ws_fsolid; }
            set { _ws_fsolid = value; }
        }
        /// <summary>
        /// WS_FPH
        /// </summary>		
        private int _ws_fph;
        public int WS_FPH
        {
            get { return _ws_fph; }
            set { _ws_fph = value; }
        }
        /// <summary>
        /// WS_FCheckS
        /// </summary>		
        private decimal _ws_fchecks;
        public decimal WS_FCheckS
        {
            get { return _ws_fchecks; }
            set { _ws_fchecks = value; }
        }
        /// <summary>
        /// WS_AddTime
        /// </summary>		
        private DateTime _ws_addtime;
        public DateTime WS_AddTime
        {
            get { return _ws_addtime; }
            set { _ws_addtime = value; }
        }
        /// <summary>
        /// WS_FName
        /// </summary>		
        private string _ws_fname;
        public string WS_FName
        {
            get { return _ws_fname; }
            set { _ws_fname = value; }
        }
        /// <summary>
        /// WS_FIsPass
        /// </summary>		
        private string _ws_fispass;
        public string WS_FIsPass
        {
            get { return _ws_fispass; }
            set { _ws_fispass = value; }
        }
        /// <summary>
        /// WS_FCheckUID
        /// </summary>		
        private string _ws_fcheckuid;
        public string WS_FCheckUID
        {
            get { return _ws_fcheckuid; }
            set { _ws_fcheckuid = value; }
        }
        /// <summary>
        /// WS_FPassMsg
        /// </summary>		
        private string _ws_fpassmsg;
        public string WS_FPassMsg
        {
            get { return _ws_fpassmsg; }
            set { _ws_fpassmsg = value; }
        }
        /// <summary>
        /// WS_FRemark
        /// </summary>		
        private string _ws_fremark;
        public string WS_FRemark
        {
            get { return _ws_fremark; }
            set { _ws_fremark = value; }
        }
        /// <summary>
        /// CreateTime
        /// </summary>		
        private DateTime _createtime;
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        /// <summary>
        /// CreateUser
        /// </summary>		
        private int _createuser;
        public int CreateUser
        {
            get { return _createuser; }
            set { _createuser = value; }
        }
        /// <summary>
        /// UpdateTime
        /// </summary>		
        private DateTime _updatetime;
        public DateTime UpdateTime
        {
            get { return _updatetime; }
            set { _updatetime = value; }
        }
        /// <summary>
        /// UpdateUser
        /// </summary>		
        private int _updateuser;
        public int UpdateUser
        {
            get { return _updateuser; }
            set { _updateuser = value; }
        }

    }



    public class Starch_check
    {

        /// <summary>
        /// ID
        /// </summary>		
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// SC_CheckTime
        /// </summary>		
        private DateTime _sc_checktime;
        public DateTime SC_CheckTime
        {
            get { return _sc_checktime; }
            set { _sc_checktime = value; }
        }
        /// <summary>
        /// SC_ware
        /// </summary>		
        private decimal _sc_ware;
        public decimal SC_ware
        {
            get { return _sc_ware; }
            set { _sc_ware = value; }
        }
        /// <summary>
        /// SC_ArchFw
        /// </summary>		
        private decimal _sc_archfw;
        public decimal SC_ArchFw
        {
            get { return _sc_archfw; }
            set { _sc_archfw = value; }
        }
        /// <summary>
        /// SC_ArchAw
        /// </summary>		
        private decimal _sc_archaw;
        public decimal SC_ArchAw
        {
            get { return _sc_archaw; }
            set { _sc_archaw = value; }
        }
        /// <summary>
        /// SC_Wcontent
        /// </summary>		
        private decimal _sc_wcontent;
        public decimal SC_Wcontent
        {
            get { return _sc_wcontent; }
            set { _sc_wcontent = value; }
        }
        /// <summary>
        /// SC_WcontentAvg
        /// </summary>		
        private decimal _sc_wcontentavg;
        public decimal SC_WcontentAvg
        {
            get { return _sc_wcontentavg; }
            set { _sc_wcontentavg = value; }
        }
        /// <summary>
        /// SC_SgelationT
        /// </summary>		
        private decimal _sc_sgelationt;
        public decimal SC_SgelationT
        {
            get { return _sc_sgelationt; }
            set { _sc_sgelationt = value; }
        }
        /// <summary>
        /// SC_SgelationS
        /// </summary>		
        private decimal _sc_sgelations;
        public decimal SC_SgelationS
        {
            get { return _sc_sgelations; }
            set { _sc_sgelations = value; }
        }
        /// <summary>
        /// SC_gelationT
        /// </summary>		
        private decimal _sc_gelationt;
        public decimal SC_gelationT
        {
            get { return _sc_gelationt; }
            set { _sc_gelationt = value; }
        }
        /// <summary>
        /// SC_gelationS
        /// </summary>		
        private int _sc_gelations;
        public int SC_gelationS
        {
            get { return _sc_gelations; }
            set { _sc_gelations = value; }
        }
        /// <summary>
        /// SC_FWcontent
        /// </summary>		
        private decimal _sc_fwcontent;
        public decimal SC_FWcontent
        {
            get { return _sc_fwcontent; }
            set { _sc_fwcontent = value; }
        }
        /// <summary>
        /// SC_FName
        /// </summary>		
        private string _sc_fname;
        public string SC_FName
        {
            get { return _sc_fname; }
            set { _sc_fname = value; }
        }
        /// <summary>
        /// SC_Fcode
        /// </summary>		
        private string _sc_fcode;
        public string SC_Fcode
        {
            get { return _sc_fcode; }
            set { _sc_fcode = value; }
        }
        /// <summary>
        /// SC_FInGoodNums
        /// </summary>		
        private int _sc_fingoodnums;
        public int SC_FInGoodNums
        {
            get { return _sc_fingoodnums; }
            set { _sc_fingoodnums = value; }
        }
        /// <summary>
        /// SC_FCheckGoodNums
        /// </summary>		
        private int _sc_fcheckgoodnums;
        public int SC_FCheckGoodNums
        {
            get { return _sc_fcheckgoodnums; }
            set { _sc_fcheckgoodnums = value; }
        }
        /// <summary>
        /// SC_FQualityMsg
        /// </summary>		
        private string _sc_fqualitymsg;
        public string SC_FQualityMsg
        {
            get { return _sc_fqualitymsg; }
            set { _sc_fqualitymsg = value; }
        }
        /// <summary>
        /// SC_FCheckUID
        /// </summary>		
        private string _sc_fcheckuid;
        public string SC_FCheckUID
        {
            get { return _sc_fcheckuid; }
            set { _sc_fcheckuid = value; }
        }
        /// <summary>
        /// SC_FRemark
        /// </summary>		
        private string _sc_fremark;
        public string SC_FRemark
        {
            get { return _sc_fremark; }
            set { _sc_fremark = value; }
        }
        /// <summary>
        /// SC_FIsPassMsg
        /// </summary>		
        private string _sc_fispassmsg;
        public string SC_FIsPassMsg
        {
            get { return _sc_fispassmsg; }
            set { _sc_fispassmsg = value; }
        }
        /// <summary>
        /// CreateTime
        /// </summary>		
        private DateTime _createtime;
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        /// <summary>
        /// CreateUser
        /// </summary>		
        private int _createuser;
        public int CreateUser
        {
            get { return _createuser; }
            set { _createuser = value; }
        }
        /// <summary>
        /// UpdateTime
        /// </summary>		
        private DateTime _updatetime;
        public DateTime UpdateTime
        {
            get { return _updatetime; }
            set { _updatetime = value; }
        }
        /// <summary>
        /// UpdateUser
        /// </summary>		
        private int _updateuser;
        public int UpdateUser
        {
            get { return _updateuser; }
            set { _updateuser = value; }
        }

    }



    public class coal_check
    {

        /// <summary>
        /// ID
        /// </summary>		
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// CC_CheckTime
        /// </summary>		
        private DateTime _cc_checktime;
        public DateTime CC_CheckTime
        {
            get { return _cc_checktime; }
            set { _cc_checktime = value; }
        }
        /// <summary>
        /// CC_AWcomponent
        /// </summary>		
        private decimal _cc_awcomponent;
        public decimal CC_AWcomponent
        {
            get { return _cc_awcomponent; }
            set { _cc_awcomponent = value; }
        }
        /// <summary>
        /// CC_AnalyseSW
        /// </summary>		
        private decimal _cc_analysesw;
        public decimal CC_AnalyseSW
        {
            get { return _cc_analysesw; }
            set { _cc_analysesw = value; }
        }
        /// <summary>
        /// CC_GreyC
        /// </summary>		
        private decimal _cc_greyc;
        public decimal CC_GreyC
        {
            get { return _cc_greyc; }
            set { _cc_greyc = value; }
        }
        /// <summary>
        /// CC_VolatilizeC
        /// </summary>		
        private decimal _cc_volatilizec;
        public decimal CC_VolatilizeC
        {
            get { return _cc_volatilizec; }
            set { _cc_volatilizec = value; }
        }
        /// <summary>
        /// CC_Carbon
        /// </summary>		
        private decimal _cc_carbon;
        public decimal CC_Carbon
        {
            get { return _cc_carbon; }
            set { _cc_carbon = value; }
        }
        /// <summary>
        /// CC_Aphosphor
        /// </summary>		
        private decimal _cc_aphosphor;
        public decimal CC_Aphosphor
        {
            get { return _cc_aphosphor; }
            set { _cc_aphosphor = value; }
        }
        /// <summary>
        /// CC_PhosphorS
        /// </summary>		
        private decimal _cc_phosphors;
        public decimal CC_PhosphorS
        {
            get { return _cc_phosphors; }
            set { _cc_phosphors = value; }
        }
        /// <summary>
        /// CC_Hcalorific
        /// </summary>		
        private decimal _cc_hcalorific;
        public decimal CC_Hcalorific
        {
            get { return _cc_hcalorific; }
            set { _cc_hcalorific = value; }
        }
        /// <summary>
        /// CC_RLcalorific
        /// </summary>		
        private decimal _cc_rlcalorific;
        public decimal CC_RLcalorific
        {
            get { return _cc_rlcalorific; }
            set { _cc_rlcalorific = value; }
        }
        /// <summary>
        /// CC_CheckUID
        /// </summary>		
        private string _cc_checkuid;
        public string CC_CheckUID
        {
            get { return _cc_checkuid; }
            set { _cc_checkuid = value; }
        }
        /// <summary>
        /// CC_Remark
        /// </summary>		
        private string _cc_remark;
        public string CC_Remark
        {
            get { return _cc_remark; }
            set { _cc_remark = value; }
        }
        /// <summary>
        /// CC_IsPass
        /// </summary>		
        private string _cc_ispass;
        public string CC_IsPass
        {
            get { return _cc_ispass; }
            set { _cc_ispass = value; }
        }
        /// <summary>
        /// CC_IsPassMsg
        /// </summary>		
        private string _cc_ispassmsg;
        public string CC_IsPassMsg
        {
            get { return _cc_ispassmsg; }
            set { _cc_ispassmsg = value; }
        }
        /// <summary>
        /// CC_FAWcomponent
        /// </summary>		
        private decimal _cc_fawcomponent;
        public decimal CC_FAWcomponent
        {
            get { return _cc_fawcomponent; }
            set { _cc_fawcomponent = value; }
        }
        /// <summary>
        /// CC_FAnalyseSW
        /// </summary>		
        private decimal _cc_fanalysesw;
        public decimal CC_FAnalyseSW
        {
            get { return _cc_fanalysesw; }
            set { _cc_fanalysesw = value; }
        }
        /// <summary>
        /// CC_FGreyC
        /// </summary>		
        private decimal _cc_fgreyc;
        public decimal CC_FGreyC
        {
            get { return _cc_fgreyc; }
            set { _cc_fgreyc = value; }
        }
        /// <summary>
        /// CC_FVolatilizeC
        /// </summary>		
        private decimal _cc_fvolatilizec;
        public decimal CC_FVolatilizeC
        {
            get { return _cc_fvolatilizec; }
            set { _cc_fvolatilizec = value; }
        }
        /// <summary>
        /// CC_FCarbon
        /// </summary>		
        private decimal _cc_fcarbon;
        public decimal CC_FCarbon
        {
            get { return _cc_fcarbon; }
            set { _cc_fcarbon = value; }
        }
        /// <summary>
        /// CC_FAphosphor
        /// </summary>		
        private decimal _cc_faphosphor;
        public decimal CC_FAphosphor
        {
            get { return _cc_faphosphor; }
            set { _cc_faphosphor = value; }
        }
        /// <summary>
        /// CC_FPhosphorS
        /// </summary>		
        private decimal _cc_fphosphors;
        public decimal CC_FPhosphorS
        {
            get { return _cc_fphosphors; }
            set { _cc_fphosphors = value; }
        }
        /// <summary>
        /// CC_FHcalorific
        /// </summary>		
        private decimal _cc_fhcalorific;
        public decimal CC_FHcalorific
        {
            get { return _cc_fhcalorific; }
            set { _cc_fhcalorific = value; }
        }
        /// <summary>
        /// CC_FRLcalorific
        /// </summary>		
        private decimal _cc_frlcalorific;
        public decimal CC_FRLcalorific
        {
            get { return _cc_frlcalorific; }
            set { _cc_frlcalorific = value; }
        }
        /// <summary>
        /// CC_FName
        /// </summary>		
        private string _cc_fname;
        public string CC_FName
        {
            get { return _cc_fname; }
            set { _cc_fname = value; }
        }
        /// <summary>
        /// CreateTime
        /// </summary>		
        private DateTime _createtime;
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        /// <summary>
        /// CreateUser
        /// </summary>		
        private int _createuser;
        public int CreateUser
        {
            get { return _createuser; }
            set { _createuser = value; }
        }
        /// <summary>
        /// UpdateTime
        /// </summary>		
        private DateTime _updatetime;
        public DateTime UpdateTime
        {
            get { return _updatetime; }
            set { _updatetime = value; }
        }
        /// <summary>
        /// UpdateUser
        /// </summary>		
        private int _updateuser;
        public int UpdateUser
        {
            get { return _updateuser; }
            set { _updateuser = value; }
        }

    }

    #endregion 



    #region 统计实体
    public class Stattis_day
    {

        /// <summary>
        /// ID
        /// </summary>		
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// SD_addtime
        /// </summary>		
        private DateTime _sd_addtime;
        public DateTime SD_addtime
        {
            get { return _sd_addtime; }
            set { _sd_addtime = value; }
        }
        /// <summary>
        /// SD_name
        /// </summary>		
        private string _sd_name;
        public string SD_name
        {
            get { return _sd_name; }
            set { _sd_name = value; }
        }
        /// <summary>
        /// SD_CSID
        /// </summary>		
        private int _sd_csid;
        public int SD_CSID
        {
            get { return _sd_csid; }
            set { _sd_csid = value; }
        }
        /// <summary>
        /// SD_line
        /// </summary>		
        private string _sd_line;
        public string SD_line
        {
            get { return _sd_line; }
            set { _sd_line = value; }
        }
        /// <summary>
        /// SD_breakQS1
        /// </summary>		
        private decimal _sd_breakqs1;
        public decimal SD_breakQS1
        {
            get { return _sd_breakqs1; }
            set { _sd_breakqs1 = value; }
        }
        /// <summary>
        /// SD_breakQS2
        /// </summary>		
        private decimal _sd_breakqs2;
        public decimal SD_breakQS2
        {
            get { return _sd_breakqs2; }
            set { _sd_breakqs2 = value; }
        }
        /// <summary>
        /// SD_breakQS3
        /// </summary>		
        private decimal _sd_breakqs3;
        public decimal SD_breakQS3
        {
            get { return _sd_breakqs3; }
            set { _sd_breakqs3 = value; }
        }
        /// <summary>
        /// SD_changPer1
        /// </summary>		
        private decimal _sd_changper1;
        public decimal SD_changPer1
        {
            get { return _sd_changper1; }
            set { _sd_changper1 = value; }
        }
        /// <summary>
        /// SD_changPer2
        /// </summary>		
        private decimal _sd_changper2;
        public decimal SD_changPer2
        {
            get { return _sd_changper2; }
            set { _sd_changper2 = value; }
        }
        /// <summary>
        /// SD_changPer3
        /// </summary>		
        private decimal _sd_changper3;
        public decimal SD_changPer3
        {
            get { return _sd_changper3; }
            set { _sd_changper3 = value; }
        }
        /// <summary>
        /// SD_HD1
        /// </summary>		
        private decimal _sd_hd1;
        public decimal SD_HD1
        {
            get { return _sd_hd1; }
            set { _sd_hd1 = value; }
        }
        /// <summary>
        /// SD_HD2
        /// </summary>		
        private decimal _sd_hd2;
        public decimal SD_HD2
        {
            get { return _sd_hd2; }
            set { _sd_hd2 = value; }
        }
        /// <summary>
        /// CreateTime
        /// </summary>		
        private DateTime _createtime;
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        /// <summary>
        /// CreateUser
        /// </summary>		
        private int _createuser;
        public int CreateUser
        {
            get { return _createuser; }
            set { _createuser = value; }
        }
        /// <summary>
        /// UpdateTime
        /// </summary>		
        private DateTime _updatetime;
        public DateTime UpdateTime
        {
            get { return _updatetime; }
            set { _updatetime = value; }
        }
        /// <summary>
        /// UpdateUser
        /// </summary>		
        private int _updateuser;
        public int UpdateUser
        {
            get { return _updateuser; }
            set { _updateuser = value; }
        }

    }


    public class Stattis_Hot
    {

        /// <summary>
        /// ID
        /// </summary>		
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// lan_hao
        /// </summary>		
        private int _lan_hao;
        public int lan_hao
        {
            get { return _lan_hao; }
            set { _lan_hao = value; }
        }
        /// <summary>
        /// juan_hao
        /// </summary>		
        private int _juan_hao;
        public int juan_hao
        {
            get { return _juan_hao; }
            set { _juan_hao = value; }
        }
        /// <summary>
        /// hot_front
        /// </summary>		
        private decimal _hot_front;
        public decimal hot_front
        {
            get { return _hot_front; }
            set { _hot_front = value; }
        }
        /// <summary>
        /// hot_afterTotal
        /// </summary>		
        private decimal _hot_aftertotal;
        public decimal hot_afterTotal
        {
            get { return _hot_aftertotal; }
            set { _hot_aftertotal = value; }
        }
        /// <summary>
        /// Water_per
        /// </summary>		
        private decimal _water_per;
        public decimal Water_per
        {
            get { return _water_per; }
            set { _water_per = value; }
        }
        /// <summary>
        /// release_d1
        /// </summary>		
        private decimal _release_d1;
        public decimal release_d1
        {
            get { return _release_d1; }
            set { _release_d1 = value; }
        }
        /// <summary>
        /// release_d2
        /// </summary>		
        private decimal _release_d2;
        public decimal release_d2
        {
            get { return _release_d2; }
            set { _release_d2 = value; }
        }
        /// <summary>
        /// release_d3
        /// </summary>		
        private decimal _release_d3;
        public decimal release_d3
        {
            get { return _release_d3; }
            set { _release_d3 = value; }
        }
        /// <summary>
        /// release_d4
        /// </summary>		
        private decimal _release_d4;
        public decimal release_d4
        {
            get { return _release_d4; }
            set { _release_d4 = value; }
        }
        /// <summary>
        /// horizontal_d1
        /// </summary>		
        private decimal _horizontal_d1;
        public decimal horizontal_d1
        {
            get { return _horizontal_d1; }
            set { _horizontal_d1 = value; }
        }
        /// <summary>
        /// horizontal_d2
        /// </summary>		
        private decimal _horizontal_d2;
        public decimal horizontal_d2
        {
            get { return _horizontal_d2; }
            set { _horizontal_d2 = value; }
        }
        /// <summary>
        /// horizontal_d3
        /// </summary>		
        private decimal _horizontal_d3;
        public decimal horizontal_d3
        {
            get { return _horizontal_d3; }
            set { _horizontal_d3 = value; }
        }
        /// <summary>
        /// horizontal_d4
        /// </summary>		
        private decimal _horizontal_d4;
        public decimal horizontal_d4
        {
            get { return _horizontal_d4; }
            set { _horizontal_d4 = value; }
        }
        /// <summary>
        /// CreateTime
        /// </summary>		
        private DateTime _createtime;
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        /// <summary>
        /// CreateUser
        /// </summary>		
        private int _createuser;
        public int CreateUser
        {
            get { return _createuser; }
            set { _createuser = value; }
        }
        /// <summary>
        /// UpdateTime
        /// </summary>		
        private DateTime _updatetime;
        public DateTime UpdateTime
        {
            get { return _updatetime; }
            set { _updatetime = value; }
        }
        /// <summary>
        /// UpdateUser
        /// </summary>		
        private int _updateuser;
        public int UpdateUser
        {
            get { return _updateuser; }
            set { _updateuser = value; }
        }

    }



    public class Stattis_Kg
    {

        /// <summary>
        /// ID
        /// </summary>		
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// sk_addTime
        /// </summary>		
        private DateTime _sk_addtime;
        public DateTime sk_addTime
        {
            get { return _sk_addtime; }
            set { _sk_addtime = value; }
        }
        /// <summary>
        /// sk_name
        /// </summary>		
        private string _sk_name;
        public string sk_name
        {
            get { return _sk_name; }
            set { _sk_name = value; }
        }
        /// <summary>
        /// sk_juanW
        /// </summary>		
        private decimal _sk_juanw;
        public decimal sk_juanW
        {
            get { return _sk_juanw; }
            set { _sk_juanw = value; }
        }
        /// <summary>
        /// sk_juanH
        /// </summary>		
        private int _sk_juanh;
        public int sk_juanH
        {
            get { return _sk_juanh; }
            set { _sk_juanh = value; }
        }
        /// <summary>
        /// sk_juanC
        /// </summary>		
        private int _sk_juanc;
        public int sk_juanC
        {
            get { return _sk_juanc; }
            set { _sk_juanc = value; }
        }
        /// <summary>
        /// sk_rangw
        /// </summary>		
        private int _sk_rangw;
        public int sk_rangw
        {
            get { return _sk_rangw; }
            set { _sk_rangw = value; }
        }
        /// <summary>
        /// sk_rangnum
        /// </summary>		
        private int _sk_rangnum;
        public int sk_rangnum
        {
            get { return _sk_rangnum; }
            set { _sk_rangnum = value; }
        }
        /// <summary>
        /// sk_clobkgw
        /// </summary>		
        private decimal _sk_clobkgw;
        public decimal sk_clobkgw
        {
            get { return _sk_clobkgw; }
            set { _sk_clobkgw = value; }
        }
        /// <summary>
        /// sk_kg1
        /// </summary>		
        private decimal _sk_kg1;
        public decimal sk_kg1
        {
            get { return _sk_kg1; }
            set { _sk_kg1 = value; }
        }
        /// <summary>
        /// sk_kg2
        /// </summary>		
        private decimal _sk_kg2;
        public decimal sk_kg2
        {
            get { return _sk_kg2; }
            set { _sk_kg2 = value; }
        }
        /// <summary>
        /// sk_kg3
        /// </summary>		
        private decimal _sk_kg3;
        public decimal sk_kg3
        {
            get { return _sk_kg3; }
            set { _sk_kg3 = value; }
        }
        /// <summary>
        /// sk_kg4
        /// </summary>		
        private decimal _sk_kg4;
        public decimal sk_kg4
        {
            get { return _sk_kg4; }
            set { _sk_kg4 = value; }
        }
        /// <summary>
        /// sk_hd1
        /// </summary>		
        private decimal _sk_hd1;
        public decimal sk_hd1
        {
            get { return _sk_hd1; }
            set { _sk_hd1 = value; }
        }
        /// <summary>
        /// sk_hd2
        /// </summary>		
        private decimal _sk_hd2;
        public decimal sk_hd2
        {
            get { return _sk_hd2; }
            set { _sk_hd2 = value; }
        }
        /// <summary>
        /// sk_hd3
        /// </summary>		
        private decimal _sk_hd3;
        public decimal sk_hd3
        {
            get { return _sk_hd3; }
            set { _sk_hd3 = value; }
        }
        /// <summary>
        /// sk_hd4
        /// </summary>		
        private decimal _sk_hd4;
        public decimal sk_hd4
        {
            get { return _sk_hd4; }
            set { _sk_hd4 = value; }
        }
        /// <summary>
        /// sk_hd5
        /// </summary>		
        private decimal _sk_hd5;
        public decimal sk_hd5
        {
            get { return _sk_hd5; }
            set { _sk_hd5 = value; }
        }
        /// <summary>
        /// sk_hd6
        /// </summary>		
        private decimal _sk_hd6;
        public decimal sk_hd6
        {
            get { return _sk_hd6; }
            set { _sk_hd6 = value; }
        }
        /// <summary>
        /// sk_hd7
        /// </summary>		
        private decimal _sk_hd7;
        public decimal sk_hd7
        {
            get { return _sk_hd7; }
            set { _sk_hd7 = value; }
        }
        /// <summary>
        /// sk_hd8
        /// </summary>		
        private decimal _sk_hd8;
        public decimal sk_hd8
        {
            get { return _sk_hd8; }
            set { _sk_hd8 = value; }
        }
        /// <summary>
        /// sk_hd9
        /// </summary>		
        private decimal _sk_hd9;
        public decimal sk_hd9
        {
            get { return _sk_hd9; }
            set { _sk_hd9 = value; }
        }
        /// <summary>
        /// sk_hd10
        /// </summary>		
        private decimal _sk_hd10;
        public decimal sk_hd10
        {
            get { return _sk_hd10; }
            set { _sk_hd10 = value; }
        }
        /// <summary>
        /// sk_kg5
        /// </summary>		
        private decimal _sk_kg5;
        public decimal sk_kg5
        {
            get { return _sk_kg5; }
            set { _sk_kg5 = value; }
        }
        /// <summary>
        /// sk_kgavg
        /// </summary>		
        private decimal _sk_kgavg;
        public decimal sk_kgavg
        {
            get { return _sk_kgavg; }
            set { _sk_kgavg = value; }
        }
        /// <summary>
        /// sk_kgCV
        /// </summary>		
        private decimal _sk_kgcv;
        public decimal sk_kgCV
        {
            get { return _sk_kgcv; }
            set { _sk_kgcv = value; }
        }
        /// <summary>
        /// sk_kghd
        /// </summary>		
        private decimal _sk_kghd;
        public decimal sk_kghd
        {
            get { return _sk_kghd; }
            set { _sk_kghd = value; }
        }
        /// <summary>
        /// sk_hdCV
        /// </summary>		
        private decimal _sk_hdcv;
        public decimal sk_hdCV
        {
            get { return _sk_hdcv; }
            set { _sk_hdcv = value; }
        }
        /// <summary>
        /// sk_hdMin
        /// </summary>		
        private decimal _sk_hdmin;
        public decimal sk_hdMin
        {
            get { return _sk_hdmin; }
            set { _sk_hdmin = value; }
        }
        /// <summary>
        /// sk_hdMax
        /// </summary>		
        private decimal _sk_hdmax;
        public decimal sk_hdMax
        {
            get { return _sk_hdmax; }
            set { _sk_hdmax = value; }
        }
        /// <summary>
        /// CreateTime
        /// </summary>		
        private DateTime _createtime;
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        /// <summary>
        /// CreateUser
        /// </summary>		
        private int _createuser;
        public int CreateUser
        {
            get { return _createuser; }
            set { _createuser = value; }
        }
        /// <summary>
        /// UpdateTime
        /// </summary>		
        private DateTime _updatetime;
        public DateTime UpdateTime
        {
            get { return _updatetime; }
            set { _updatetime = value; }
        }
        /// <summary>
        /// UpdateUser
        /// </summary>		
        private int _updateuser;
        public int UpdateUser
        {
            get { return _updateuser; }
            set { _updateuser = value; }
        }

    }

    public class Stattis_Solid
    {

        /// <summary>
        /// ID
        /// </summary>		
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// juan_hao
        /// </summary>		
        private int _juan_hao;
        public int juan_hao
        {
            get { return _juan_hao; }
            set { _juan_hao = value; }
        }
        /// <summary>
        /// zhang_d
        /// </summary>		
        private decimal _zhang_d;
        public decimal zhang_d
        {
            get { return _zhang_d; }
            set { _zhang_d = value; }
        }
        /// <summary>
        /// xu_hao
        /// </summary>		
        private int _xu_hao;
        public int xu_hao
        {
            get { return _xu_hao; }
            set { _xu_hao = value; }
        }
        /// <summary>
        /// S_CrucibleW
        /// </summary>		
        private decimal _s_cruciblew;
        public decimal S_CrucibleW
        {
            get { return _s_cruciblew; }
            set { _s_cruciblew = value; }
        }
        /// <summary>
        /// S_CrucibleFT
        /// </summary>		
        private decimal _s_crucibleft;
        public decimal S_CrucibleFT
        {
            get { return _s_crucibleft; }
            set { _s_crucibleft = value; }
        }
        /// <summary>
        /// S_CrucibleAT
        /// </summary>		
        private decimal _s_crucibleat;
        public decimal S_CrucibleAT
        {
            get { return _s_crucibleat; }
            set { _s_crucibleat = value; }
        }
        /// <summary>
        /// s_solidPer
        /// </summary>		
        private decimal _s_solidper;
        public decimal s_solidPer
        {
            get { return _s_solidper; }
            set { _s_solidper = value; }
        }
        /// <summary>
        /// CreateTime
        /// </summary>		
        private DateTime _createtime;
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        /// <summary>
        /// CreateUser
        /// </summary>		
        private int _createuser;
        public int CreateUser
        {
            get { return _createuser; }
            set { _createuser = value; }
        }
        /// <summary>
        /// UpdateTime
        /// </summary>		
        private DateTime _updatetime;
        public DateTime UpdateTime
        {
            get { return _updatetime; }
            set { _updatetime = value; }
        }
        /// <summary>
        /// UpdateUser
        /// </summary>		
        private int _updateuser;
        public int UpdateUser
        {
            get { return _updateuser; }
            set { _updateuser = value; }
        }

    }

#endregion 




}
