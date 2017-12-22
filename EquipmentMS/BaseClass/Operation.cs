using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Office.Interop;
//using Microsoft.Internal.Performance;

namespace EquipmentMS.BaseClass
{
    class Operation
    {
        DataBase data = new DataBase();

        #region 验证合法输入（0123456789.）
        /// <summary>
        /// 验证合法输入（0123456789.）
        /// </summary>
        /// <param name="strCode">验证字符</param>
        /// <returns></returns>
        public bool IsNumeric(string strCode)
        {
            if (strCode == null || strCode.Length == 0)
                return false;
            ASCIIEncoding ascii = new ASCIIEncoding();
            byte[] byteStr = ascii.GetBytes(strCode);
            foreach (byte code in byteStr)
            {
                if (code == 190||code==110)
                if (code < 48 || code > 57)
                    return false;
            }
            return true;
        }
        #endregion
        
        #region 将DataGridView控件中数据导出到Excel
        /// <summary>
        /// 将DataGridView控件中数据导出到Excel
        /// </summary>
        /// <param name="gridView">DataGridView对象</param>
        /// <param name="isShowExcle">是否显示Excel界面</param>
        /// <returns></returns>
        public bool ExportDataGridview(DataGridView gridView,bool isShowExcle)
        {
            if (gridView.Rows.Count == 0)
                return false;
            //建立Excel对象

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);
            excel.Visible = isShowExcle;
            //生成字段名称
            for (int i = 0; i < gridView.ColumnCount; i++)
            {
                excel.Cells[1, i + 1] = gridView.Columns[i].HeaderText;
            }
            //填充数据
            for (int i = 0; i < gridView.RowCount-1; i++)
            {
                for (int j = 0; j < gridView.ColumnCount; j++)
                {
                    if (gridView[j, i].ValueType == typeof(string))
                    {
                        excel.Cells[i + 2, j + 1] = "'" + gridView[j, i].Value.ToString();
                    }
                    else
                    {
                        excel.Cells[i + 2, j + 1] = gridView[j, i].Value.ToString();
                    }
                }
            }
            return true;
        }
        #endregion

        #region  设置主窗体DataGridView的Width和Visble属性。
        public int DataGridViewSetWidth(int place, int DataGridView_width)
        {
            return data.RunProc("update tb_DataGridViewList set width=" + DataGridView_width + " where place=" + place + "");
        }
        public int DataGridViewSetVisible(int place, bool check)
        {
            return data.RunProc("update tb_DataGridViewList set Visible=" + Convert.ToInt16(check) + " where place=" + place + "");
        }
        #endregion

        #region  设置本单位信息

        public int InsertUnits(string units, string linkman, string address, string tel, string memo)
        {
            return data.RunProc("insert into tb_units (units,linkman,address,tel,memo) values ('" + units + "','" + linkman + "','" + address + "','" + tel + "','" + memo + "')");
        }

        public int UpdateUnits(string units, string linkman, string address, string tel, string memo)
        {
            return data.RunProc("update tb_units set units='" + units + "',linkman='" + linkman + "',address='" + address + "',tel='" + tel + "',memo='" + memo + "'");
        }

        public DataSet GetDataSetUnits()
        {
            return data.RunProcReturn("select * from tb_units","tb_units");
        }

        #endregion

        #region  系统初始化
        public int DeleteBaseTable()
        {
            return data.RunProc("delete from tb_units "+
                "delete from tb_BaseBgry " +
                "delete from tb_BaseCfdd " +
                "delete from tb_BaseDefaultNO " +
                "delete from tb_BaseJldw " +
                "delete from tb_BaseQlfs " +
                "delete from tb_BaseSybm " +
                "delete from tb_BaseSyqk " +
                "delete from tb_BaseZcmc " +
                "delete from tb_BaseZjfs " +
                "delete from tb_User");
        }

        public int DeleteOperationTable()
        {
            return data.RunProc("delete from tb_zcMain delete from tb_zcClear");
        }
        #endregion

        #region  设置主窗体TreeView菜单项
        /// <summary>
        /// 获取TreeView菜单项
        /// </summary>
        /// <returns></returns>
        public DataSet TreeFill()
        {
            return data.RunProcReturn("select * from tb_BaseZclb select * from tb_BaseZjfs select * from tb_BaseSybm select * from tb_BaseSyqk select * from tb_BaseCfdd select * from tb_BaseBgry", "tb_zclb");
        }
        /// <summary>
        /// 获取主窗体DataGridView控件的属性设置
        /// </summary>
        /// <returns></returns>
        public DataSet GetDataGridViewList()
        {
            return data.RunProcReturn("select * from tb_DataGridViewList", "tb_DataGridViewList");
        }
        /// <summary>
        /// 获取所有固定资产信息
        /// </summary>
        /// <returns></returns>
        #endregion

        #region　资产查询
        /// <summary>
        /// 获得所有资产
        /// </summary>
        /// <returns></returns>
        public DataSet GetDataSetZC()
        {
            return data.RunProcReturn("select * from tb_zcMain ORDER BY ID", "tb_zcMain");
        }
        public DataSet GetDataSetZC(string findTitle,string findContent)
        {
            return data.RunProcReturn("select * from tb_zcMain where " + findTitle + "='" + findContent + "' ORDER BY ID", "tb_zcMain");
        }
        #endregion

        #region 设置资产分类
        /// <summary>
        /// 查询现有资产名称列表
        /// </summary>
        /// <param name="zcName">资产名称</param>
        /// <returns></returns>
        public DataSet GetDataSetBaseZclb(string zcName)
        {
            return data.RunProcReturn("select * from tb_BaseZclb where zclb='" + zcName + "'","tb_BaseZclb");
        }
        public DataSet GetDataSetBaseZclb()
        {
            return data.RunProcReturn("select * from tb_BaseZclb where firstID=1", "tb_BaseZclb");
        }
        /// <summary>
        /// 添加资产名称
        /// </summary>
        /// <param name="firstID"></param>
        /// <param name="zclb"></param>
        /// <param name="secondID"></param>
        /// <returns></returns>
        public int insertBaseZclb(string firstID,string zclb,string secondID)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@firstID",  SqlDbType.VarChar, 10, firstID),
                						data.MakeInParam("@zclb",  SqlDbType.VarChar, 10, zclb),
                						data.MakeInParam("@secondID",  SqlDbType.VarChar, 10, secondID),
			};
            return (data.RunProc("INSERT INTO tb_BaseZclb (firstID,zclb,secondID) VALUES (@firstID,@zclb,@secondID)", prams));
        }
        /// <summary>
        /// 删除指定ＩＤ的资产名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int deleteBaseZclb(int id)
        {
            return data.RunProc("delete from tb_BaseZclb where id='" + id + "'");
        }
        /// <summary>
        /// 修改指定ＩＤ的资产名称
        /// </summary>
        /// <param name="zclb"></param>
        /// <returns></returns>
        public int UpdateBaseZclb(int ID, string zclb)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",SqlDbType.Int,4,ID),
                						data.MakeInParam("@zclb",  SqlDbType.VarChar, 10, zclb),
			};
            return (data.RunProc("UPdate tb_BaseZclb set zclb=@zclb where id='" + ID + "'", prams));
        }
        #endregion

        #region  基本资料管理---查询
        public DataSet GetDataSetBaseZcmc()
        {
            return data.RunProcReturn("select * from tb_BaseZcmc", "tb_BaseZcmc");
        }
        public DataSet GetDataSetBaseZjfs()
        {
            return data.RunProcReturn("select * from tb_BaseZjfs", "tb_BaseZjfs");
        }
        public DataSet GetDataSetBaseSybm()
        {
            return data.RunProcReturn("select * from tb_BaseSybm", "tb_BaseSybm");
        }
        public DataSet GetDataSetBaseSyqk()
        {
            return data.RunProcReturn("select * FROM tb_BaseSyqk", "tb_BaseSyqk");
        }
        public DataSet GetDataSetBaseCfdd()
        {
            return data.RunProcReturn("select * from tb_BaseCfdd", "tb_BaseCfdd");
        }
        public DataSet GetDataSetBaseBgry()
        {
            return data.RunProcReturn("select * from tb_BaseBgry","tb_BaseBgry");
        }
        public DataSet GetDataSetBaseJldw()
        {
            return data.RunProcReturn("select * from tb_BaseJldw", "tb_BaseJldw");
        }
        public DataSet GetDataSetBaseQlfs()
        {
            return data.RunProcReturn("select * from tb_BaseQlfs", "tb_BaseQlfs");
            
        }
        public DataSet GetDataSetBaseBrand()
        {            
            return data.RunProcReturn("select * from tb_BaseBrand", "tb_BaseBrand");
        }

        #endregion

        #region  基本资料管理----删除
        public int DeleteBaseZcmc(string id)
        {
            return data.RunProc("delete from tb_BaseZcmc where id='" + id + "'");
        }
        public int DeleteBaseZjfs(string id)
        {
            return data.RunProc("delete from tb_BaseZjfs where id='" + id + "'");
        }
        public int DeleteBaseSybm(string id)
        {
            return data.RunProc("delete from tb_BaseSybm where id='" + id + "'");
        }
        public int DeleteBaseSyqk(string id)
        {
            return data.RunProc("delete from tb_BaseSyqk where id='" + id + "'");
        }
        public int DeleteBaseCfdd(string id)
        {
            return data.RunProc("delete from tb_BaseCfdd where id='" + id + "'");
        }
        public int DeleteBaseBgry(string id)
        {
            return data.RunProc("delete from tb_BaseBgry where id='" + id + "'");
        }
        public int DeleteBaseJldw(string id)
        {
            return data.RunProc("delete from tb_BaseJldw where id='" + id + "'");
        }
        public int DeleteBaseQlfs(string id)
        {
            return data.RunProc("delete from tb_BaseQlfs where id='" + id + "'");
           
        }
        public int DeleteBaseBrand(string id)
        {
            
            return data.RunProc("delete from tb_BaseBrand where id = '" + id + "'");
        }
        #endregion

        #region  基本资料管理－－－添加
        public int InsertBaseZcmc(string zcmc)
        {
            SqlParameter[] prams = {
                						data.MakeInParam("@zcmc",  SqlDbType.VarChar, 50, zcmc),
			};
            return (data.RunProc("INSERT INTO tb_BaseZcmc (zcmc) VALUES (@zcmc)", prams));
        }
        public int InsertBaseZjfs(string zjfs)
        {
            SqlParameter[] prams = {
                						data.MakeInParam("@zjfs",  SqlDbType.VarChar, 50, zjfs),
			};
            return (data.RunProc("INSERT INTO tb_BaseZjfs (zjfs) VALUES (@zjfs)", prams));
        }
        public int InsertBaseSybm(string sybm)
        {
            SqlParameter[] prams = {
                						data.MakeInParam("@sybm",  SqlDbType.VarChar, 50, sybm),
			};
            return (data.RunProc("INSERT INTO tb_BaseSybm (sybm) VALUES (@sybm)", prams));
        }
        public int InsertBaseSyqk(string syqk)
        {
            SqlParameter[] prams = {
                						data.MakeInParam("@syqk",  SqlDbType.VarChar, 50, syqk),
			};
            return (data.RunProc("INSERT INTO tb_BaseSyqk (syqk) VALUES (@syqk)", prams));
        }
        public int InsertBaseCfdd(string cfdd,string departMent)
        {
            SqlParameter[] prams = {
                						data.MakeInParam("@cfdd",  SqlDbType.VarChar, 50, cfdd),
                                        data.MakeInParam("@departMent",SqlDbType.VarChar,50,departMent),
			};
            return (data.RunProc("INSERT INTO tb_BaseCfdd (cfdd,DepartMent) VALUES (@cfdd,@departMent)", prams));
        }
        public int InsertBaseBgry(string bgry, string departMent)
        {
            SqlParameter[] prams = {
                						data.MakeInParam("@bgry",  SqlDbType.VarChar, 50, bgry),
                                         data.MakeInParam("@departMent",SqlDbType.VarChar,50,departMent),
			};
            return (data.RunProc("INSERT INTO tb_BaseBgry (bgry,DepartMent) VALUES (@bgry,@departMent)", prams));
        }
        public int InsertBaseJldw(string jldw)
        {
            SqlParameter[] prams = {
                						data.MakeInParam("@jldw",  SqlDbType.VarChar, 50, jldw),
			};
            return (data.RunProc("INSERT INTO tb_BaseJldw (jldw) VALUES (@jldw)", prams));
        }
        public int InsertBaseQlfs(string qlfs)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@qlfs",  SqlDbType.VarChar, 50, qlfs),
            };
            return (data.RunProc("INSERT INTO tb_BaseQlfs (qlfs) VALUES (@qlfs)", prams));
        
        }

        public int InsertBaseBrand(string brandName)
        {
           
            SqlParameter[] prams = {
                						data.MakeInParam("@BrandName",  SqlDbType.VarChar, 50, brandName),
			};
            return (data.RunProc("INSERT INTO tb_BaseBrand (BrandName) VALUES (@BrandName)", prams));
        }
        #endregion

        #region   固定资产编号设置
        /// <summary>
        /// 查询是否存在默认固定资产编号
        /// </summary>
        /// <returns></returns>
        public DataSet GetDataSetBaseDefaultNO()
        {
            return data.RunProcReturn("select * from tb_BaseDefaultNO", "tb_BaseDefaultNO");
        }
        /// <summary>
        /// 创建默认固定资产编号
        /// </summary>
        /// <param name="firstNO"></param>
        /// <param name="defaultNo"></param>
        /// <returns></returns>
        public int InsertBaseDefaultNO(string firstNO, int defaultNo)
        {
            SqlParameter[] prams = {
                						data.MakeInParam("@firstNO",  SqlDbType.VarChar, 50, firstNO),
                                        data.MakeInParam("@defaultNO",  SqlDbType.Int, 4, defaultNo),
			};
            return (data.RunProc("INSERT INTO tb_BaseDefaultNO (firstNO,defaultNO) VALUES (@firstNO,@defaultNO)", prams));
        }
        /// <summary>
        /// 修改默认固定资产编号
        /// </summary>
        /// <param name="firstNO"></param>
        /// <param name="defaultNo"></param>
        /// <returns></returns>
        public int UpdateBaseDefaultNO(string firstNO, int defaultNo)
        {
            SqlParameter[] prams = {
                						data.MakeInParam("@firstNO",  SqlDbType.VarChar, 50, firstNO),
                                        data.MakeInParam("@defaultNO",  SqlDbType.Int, 4, defaultNo),
			};
            return (data.RunProc("Update tb_BaseDefaultNO Set firstNO=@firstNO,defaultNO=@defaultNO where id=1", prams));
        }
        #endregion

        #region   固定资产管理
        public int InsertZcMain(cZcMain zcMain)
        {
            SqlParameter[] prams = {
                				data.MakeInParam("@bh",  SqlDbType.VarChar, 50, zcMain.BH),
                                data.MakeInParam("@mc",  SqlDbType.VarChar, 50, zcMain.MC),
                    			data.MakeInParam("@xh",  SqlDbType.VarChar, 50, zcMain.XH),
                        		data.MakeInParam("@zclb",  SqlDbType.VarChar, 50, zcMain.Zclb),
                        		data.MakeInParam("@xxpz",  SqlDbType.VarChar, 200, zcMain.Xxpz),
                        		data.MakeInParam("@gjbh",  SqlDbType.VarChar, 50, zcMain.Gjbh),
                        		data.MakeInParam("@sccj",  SqlDbType.VarChar, 50, zcMain.Sccj),
                        		data.MakeInParam("@ccrq",  SqlDbType.DateTime, 8, zcMain.Ccrq),

                        		data.MakeInParam("@zjfs",  SqlDbType.VarChar, 50, zcMain.Zjfs),
                        		data.MakeInParam("@sybm",  SqlDbType.VarChar, 50, zcMain.Sybm),
                        		data.MakeInParam("@syqk",  SqlDbType.VarChar, 50, zcMain.Syqk),
                        		data.MakeInParam("@cfdd",  SqlDbType.VarChar, 50, zcMain.Cfdd),
                        		data.MakeInParam("@bgry",  SqlDbType.VarChar, 50, zcMain.Bgry),
                        		data.MakeInParam("@rzrq",  SqlDbType.DateTime, 8, zcMain.Rzrq),

                        		data.MakeInParam("@sl",  SqlDbType.Int, 4, zcMain.SL),
                        		data.MakeInParam("@dw",  SqlDbType.VarChar, 20, zcMain.DW),
                        		data.MakeInParam("@dj",  SqlDbType.Float, 8, zcMain.DJ),
                        		data.MakeInParam("@yz",  SqlDbType.Float, 8, zcMain.YZ),
                        		data.MakeInParam("@ljzj",  SqlDbType.Float, 8, zcMain.Ljzj),
                        		data.MakeInParam("@jz",  SqlDbType.Float, 8, zcMain.JZ),
                        		data.MakeInParam("@jczl",  SqlDbType.Float, 8, zcMain.Jczl),
                        		data.MakeInParam("@zjff",  SqlDbType.VarChar, 20, zcMain.Zjff),
                        		data.MakeInParam("@nx",  SqlDbType.Int, 4, zcMain.Nx),
                        		data.MakeInParam("@login",  SqlDbType.DateTime, 20, zcMain.Login),
                        		data.MakeInParam("@loginer",  SqlDbType.VarChar, 8, zcMain.Loginer),
                                   data.MakeInParam("@gxrq",SqlDbType.DateTime,20,zcMain.Gxrq),
                                data.MakeInParam("@tm",SqlDbType.VarChar,20,zcMain.Tm),
                                  data.MakeInParam("@xlh",SqlDbType.VarChar,20,zcMain.Xlh),
                              data.MakeInParam("@Brand",SqlDbType.VarChar,20,zcMain.Brand),

			};
            return (data.RunProc("INSERT INTO tb_zcMain (bh,mc,xh,zclb,xxpz,gbbh,sccj,ccrq," +
            "zjfs,sybm,syqk,cfdd,bgry,rzrq,sl,dw,dj,zcyz,ljzj,zcjz,jczl,zjff,nx,djrq,djr,gxrq,tm,xlh,Brand)" +
            "VALUES (@bh,@mc,@xh,@zclb,@xxpz,@gjbh,@sccj,@ccrq" +
            ",@zjfs,@sybm,@syqk,@cfdd,@bgry,@rzrq," +
            "@sl,@dw,@dj,@yz,@ljzj,@jz,@jczl,@zjff,@nx,@login,@loginer,@gxrq,@tm,@xlh,@Brand)", prams));
        }

        public int UpdateZcMain(cZcMain zcMain)
        {
            SqlParameter[] prams = {
                				data.MakeInParam("@bh",  SqlDbType.VarChar, 50, zcMain.BH),
                                data.MakeInParam("@mc",  SqlDbType.VarChar, 50, zcMain.MC),
                    			data.MakeInParam("@xh",  SqlDbType.VarChar, 50, zcMain.XH),
                        		data.MakeInParam("@zclb",  SqlDbType.VarChar, 50, zcMain.Zclb),
                        		data.MakeInParam("@xxpz",  SqlDbType.VarChar, 200, zcMain.Xxpz),
                        		data.MakeInParam("@gjbh",  SqlDbType.VarChar, 50, zcMain.Gjbh),
                        		data.MakeInParam("@sccj",  SqlDbType.VarChar, 50, zcMain.Sccj),
                        		data.MakeInParam("@ccrq",  SqlDbType.DateTime, 8, zcMain.Ccrq),

                        		data.MakeInParam("@zjfs",  SqlDbType.VarChar, 50, zcMain.Zjfs),
                        		data.MakeInParam("@sybm",  SqlDbType.VarChar, 50, zcMain.Sybm),
                        		data.MakeInParam("@syqk",  SqlDbType.VarChar, 50, zcMain.Syqk),
                        		data.MakeInParam("@cfdd",  SqlDbType.VarChar, 50, zcMain.Cfdd),
                        		data.MakeInParam("@bgry",  SqlDbType.VarChar, 50, zcMain.Bgry),
                        		data.MakeInParam("@rzrq",  SqlDbType.DateTime, 8, zcMain.Rzrq),

                        		data.MakeInParam("@sl",  SqlDbType.Int, 4, zcMain.SL),
                        		data.MakeInParam("@dw",  SqlDbType.VarChar, 20, zcMain.DW),
                        		data.MakeInParam("@dj",  SqlDbType.Float, 8, zcMain.DJ),
                        		data.MakeInParam("@yz",  SqlDbType.Float, 8, zcMain.YZ),
                        		data.MakeInParam("@ljzj",  SqlDbType.Float, 8, zcMain.Ljzj),
                        		data.MakeInParam("@jz",  SqlDbType.Float, 8, zcMain.JZ),
                        		data.MakeInParam("@jczl",  SqlDbType.Float, 8, zcMain.Jczl),
                        		data.MakeInParam("@zjff",  SqlDbType.VarChar, 20, zcMain.Zjff),
                        		data.MakeInParam("@nx",  SqlDbType.Int, 4, zcMain.Nx),
                        		data.MakeInParam("@login",  SqlDbType.DateTime, 20, zcMain.Login),
                        		data.MakeInParam("@loginer",  SqlDbType.VarChar, 8, zcMain.Loginer),
                                
                                data.MakeInParam("@gxrq",SqlDbType.DateTime,20,zcMain.Gxrq),
                                data.MakeInParam("@tm",SqlDbType.VarChar,20,zcMain.Tm),
            data.MakeInParam("xlh",SqlDbType.VarChar,20,zcMain.Xlh),
            data.MakeInParam("Brand",SqlDbType.VarChar,20,zcMain.Brand),

			};
            return (data.RunProc("Update tb_zcMain Set mc=@mc,xh=@xh," +
                "zclb=@zclb,xxpz=@xxpz,gbbh=@gjbh,sccj=@sccj,ccrq=@ccrq,zjfs=@zjfs," +
                "sybm=@sybm,syqk=@syqk,cfdd=@cfdd,bgry=@bgry,rzrq=@rzrq,sl=@sl,dw=@dw," +
                "dj=@dj,zcyz=@yz,ljzj=@ljzj,zcjz=@jz,jczl=@jczl,zjff=@zjff," +
                "nx=@nx,djrq=@login,djr=@loginer,gxrq=@gxrq ,tm = @tm,xlh = @xlh,Brand = @brand" +
           " where bh=@bh", prams));
        }
        /// <summary>
        /// 删除固定资产
        /// </summary>
        /// <param name="BH"></param>
        /// <returns></returns>
        public int DeleteZcMain(string BH)
        {
            return data.RunProc("delete from tb_zcMain where bh='" + BH + "'");
        }
        /// <summary>
        /// 获取指定的固定资产
        /// </summary>
        /// <param name="BH"></param>
        /// <returns></returns>
        public DataSet GetDataSetZC(string BH)
        {
            return data.RunProcReturn("select * from tb_zcMain where bh='" + BH + "'","tb_zcMain");
        }
        /// <summary>
        /// 清理固定资产（清理到tb_zcClear中）
        /// </summary>
        /// <param name="zcMain"></param>
        /// <returns></returns>
        public int ClearZcMain(cZcMain zcMain)
        {
            SqlParameter[] prams = {
                				data.MakeInParam("@bh",  SqlDbType.VarChar, 50, zcMain.BH),
                                data.MakeInParam("@mc",  SqlDbType.VarChar, 50, zcMain.MC),
                    			data.MakeInParam("@xh",  SqlDbType.VarChar, 50, zcMain.XH),
                        		data.MakeInParam("@xxpz",  SqlDbType.VarChar, 200, zcMain.Xxpz),

                        		data.MakeInParam("@syqk",  SqlDbType.VarChar, 50, zcMain.Syqk),
                        		data.MakeInParam("@sybm",  SqlDbType.VarChar, 50, zcMain.Sybm),
                        		data.MakeInParam("@bgry",  SqlDbType.VarChar, 50, zcMain.Bgry),
                        		data.MakeInParam("@cfdd",  SqlDbType.VarChar, 50, zcMain.Cfdd),

                        		data.MakeInParam("@qlr",  SqlDbType.VarChar, 8, zcMain.Qlr),
                                data.MakeInParam("@qlfs",  SqlDbType.VarChar, 50, zcMain.Qlfs),
                                data.MakeInParam("@qlrq",  SqlDbType.DateTime, 8, zcMain.Qlrq),
                                data.MakeInParam("@pzr",  SqlDbType.VarChar, 20, zcMain.Pzr),
                                data.MakeInParam("@memo",  SqlDbType.VarChar, 255, zcMain.Memo),
			};
            return (data.RunProc("INSERT INTO tb_zcClear (bh,mc,xh,xxpz,syqk,sybm,bgry,cfdd,qlr,qlfs,qlrq,pzr,memo)" +
            "VALUES (@bh,@mc,@xh,@xxpz,@syqk,@sybm,@bgry,@cfdd,@qlr,@qlfs,@qlrq,@pzr,@memo)", prams));
        }
        #endregion

        #region  主窗体－－固定资产查询
        public DataSet GetDataSetBaseZcMain_mc(string mc)
        {
            return data.RunProcReturn("select * from tb_zcMain where mc='" + mc + "'", "tb_BaseZcmc");
        }

        public DataSet GetDataSetBaseZcMain_zclb(string zclb)
        {
            return data.RunProcReturn("select * from tb_zcMain where zclb='" + zclb + "'", "tb_BaseZcmc");
        }

        public DataSet GetDataSetBaseZcMain_zjfs(string zjfs)
        {
            return data.RunProcReturn("select * from tb_zcMain where zjfs='" + zjfs + "'", "tb_BaseZcmc");
        }
        public DataSet GetDataSetBaseZcMain_sybm(string sybm)
        {
            return data.RunProcReturn("select * from tb_zcMain where sybm='" + sybm + "'", "tb_BaseZcmc");
        }
        public DataSet GetDataSetBaseZcMain_syqk(string syqk)
        {
            return data.RunProcReturn("select * from tb_zcMain where syqk='" + syqk + "'", "tb_BaseZcmc");
        }
        public DataSet GetDataSetBaseZcMain_cfdd(string cfdd)
        {
            return data.RunProcReturn("select * from tb_zcMain where cfdd='" + cfdd + "'", "tb_BaseZcmc");
        }

        public DataSet GetDataSetBaseZcMain_bgry(string bgry)
        {
            return data.RunProcReturn("select * from tb_zcMain where bgry='" + bgry + "'", "tb_BaseZcmc");
        }
        #endregion

        #region 固定资产清理查询
        /// <summary>
        /// 获得所有固定资产
        /// </summary>
        /// <returns></returns>
        public DataSet GetDataSetzcClear()
        {
            return data.RunProcReturn("select bh as 资产编号,mc as 资产名称,xh as 资产型号, xxpz as 详细配置,syqk as 使用情况,sybm as 使用部门,bgry as 保管人员,cfdd as 存放地点,qlr as 清理人,qlfs as 清理方式,qlrq as 清理日期,pzr as 批准人,memo as 备注 from tb_zcClear","tb_zcClear");
        }
        /// <summary>
        /// 查询固定资产（清理）
        /// </summary>
        /// <param name="findType"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public DataSet GetDataSetzcClear(string findType,string content)
        {
            return data.RunProcReturn("select bh as 资产编号,mc as 资产名称,xh as 资产型号, xxpz as 详细配置,syqk as 使用情况,sybm as 使用部门,bgry as 保管人员,cfdd as 存放地点,qlr as 清理人,qlfs as 清理方式,qlrq as 清理日期,pzr as 批准人,memo as 备注 from tb_zcClear where " + findType + " like '%" + content + "%'", "tb_zcClear");
        }
        /// <summary>
        /// 根据编号删除删除固定资产
        /// </summary>
        /// <param name="BH"></param>
        /// <returns></returns>
        public int DeletezcClear(string BH)
        {
            return data.RunProc("delete from tb_zcClear where bh='" + BH + "'");
        }
        #endregion

        #region  资产折旧
        /// <summary>
        /// 获得资产部分信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetDataSetZcMainSum()
        {
            return data.RunProcReturn("select bh as 资产编号,mc as 资产名称,xh as 资产型号,zjff as 折旧方法,rzrq as 入账日期, sl*dj as 资产原值, zcjz 资产净值,jczl as 净残值率,nx as 使用年限,Convert(float(8),null) as 本月折旧,null as 累计折旧 from tb_zcMain", "tab");
        }
        #endregion

        #region 操作员管理
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int InsertUser(string userName,string pwd)
        {
            SqlParameter[] prams = { 
                data.MakeInParam("@userName",SqlDbType.VarChar,50,userName),
                data.MakeInParam("@userPwd",SqlDbType.VarChar,50,pwd),
            };
            return data.RunProc("insert into tb_User (username,userpwd) values(@userName,@userPwd)", prams);
        }
        /// <summary>
        /// 修改管理员
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int UpdateUser(string id,string userName, string pwd)
        {
            SqlParameter[] prams = { 
                data.MakeInParam("@userName",SqlDbType.VarChar,50,userName),
                data.MakeInParam("@userPwd",SqlDbType.VarChar,50,pwd),
            };
            return data.RunProc("update tb_User set userName=@userName,userPwd=@userPwd where id=" + id + "", prams);
        }
        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteUser(string id)
        {
            return data.RunProc("delete from tb_user where id=" + id + "");
        }
        /// <summary>
        /// 获得所有管理员信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetDataSetUser()
        {
            return data.RunProcReturn("select ID as 用户ID,username as 用户名称,userpwd as 用户密码 from tb_user", "tb_user");
        }
        /// <summary>
        /// 根据指定的ＩＤ获得管理员信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet GetDataSetUser(string id)
        {
            return data.RunProcReturn("select * from tb_user where id='" + id + "'", "tb_user");
        }
        #endregion

        #region  系统登录

        public DataSet LoginSystem(string userName,string pwd)
        {
            return data.RunProcReturn("select * from tb_user where userName='" + userName + "'and userpwd='" + pwd + "'","tb_user");
        }

        #endregion

        #region  数据库备份与恢复--系统设置
        /// <summary>
        /// 数据库备份
        /// </summary>
        /// <param name="bakUpName">备份路径</param>
        /// <param name="format">是否格式化</param>
        public void BackUp(string bakUpName,bool format)
        {
            if(format)
                data.RunProc("BACKUP DATABASE db_EquipmentMS TO DISK ='" + bakUpName + "' with format");
            else
                data.RunProc("BACKUP DATABASE db_EquipmentMS TO DISK ='" + bakUpName + "' with noformat");
        }
        /// <summary>
        /// 恢复数据库
        /// </summary>
        /// <param name="reStoreName">指定恢复数据库路径</param>
        /// <param name="bakFile">指定恢复文件</param>
        public void ReStore(string reStoreName,int  bakFile)
        {
            data.RunProc("use master RESTORE DATABASE db_EquipmentMS from disk='" + reStoreName + "'WITH file = " + bakFile + "");
        }
        /// <summary>
        /// 获得备份数据日志
        /// </summary>
        /// <param name="strPath">指定备份文件路径</param>
        /// <returns></returns>
        public DataSet GetBakUp(string strPath)
        {
            return data.RunProcReturn("restore headeronly from disk='" + strPath + "'", "headeronly");
        }
        #endregion
    }

    #region　固定资产实体类
    public class cZcMain
    {
        private string bh="";
        private string mc="";
        private string xh="";
        private string zclb="";
        private string xxpz = "";
        private string gjbh = "";
        private string sccj = "";
        private DateTime ccrq = DateTime.Now;
        private string zjfs = "";
        private string sybm = "";
        private string syqk = "";
        private string cfdd = "";
        private string bgry = "";
        private DateTime rzrq = DateTime.Now;
        private int sl = 0;
        private string dw = "";
        private float dj = 0;
        private float yz = 0;
        private float ljzj = 0;
        private float jz = 0;
        private float jczl = 0;
        private string zjff = "";
        private int nx = 0;
        private DateTime login = DateTime.Now;
        private DateTime gxrq = DateTime.Now;
        private string loginer = "";
        private string tm = "";
        private string xlh = "";
        private string brand = "";
        /// <summary>
        /// ID
        /// </summary>
        public string BH
        {
            get { return bh; }
            set { bh = value; }
        }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string MC
        {
            get { return mc; }
            set { mc = value; }
        }
        ///<summary>
        /// 條碼
        /// </summary>
        public string Tm
        {
            get
            {
                return tm;
            }
            set
            {
                tm = value;
            }
        }
        ///<summary>
        /// 序列號
        /// </summary>
        public string Xlh
        {
            get
            {
                return xlh;
            }
            set
            {
                xlh = value;
            }
        }
        ///<summary>
        /// 品牌
        /// </summary>
        public string Brand
        {
            get
            {
                return brand;
            }
            set
            {
                brand = value;
            }
        }
        /// <summary>
        /// 型号
        /// </summary>
        public string XH
        {
            get { return xh; }
            set { xh = value; }
        }
        /// <summary>
        /// 资产列表
        /// </summary>
        public string Zclb
        {
            get { return zclb; }
            set { zclb = value; }
        }
        /// <summary>
        /// 详细配置
        /// </summary>
        public string Xxpz
        {
            get { return xxpz; }
            set { xxpz = value; }
        }
        /// <summary>
        /// 国际编号
        /// </summary>
        public string Gjbh
        {
            get { return gjbh; }
            set { gjbh = value; }
        }
        /// <summary>
        /// 出厂日期
        /// </summary>
        public DateTime Ccrq
        {
            get { return ccrq; }
            set { ccrq = value; }
        }
        ///<summary>
        /// 更新日期
        /// </summary>
        public DateTime Gxrq
        {
            get { return gxrq; }
            set { gxrq = value; }
        }
        /// <summary>
        /// 生产厂家
        /// </summary>
        public string Sccj
        {
            get { return sccj; }
            set { sccj = value; }
        }
        /// <summary>
        /// 增加方式
        /// </summary>
        public string Zjfs
        {
            get { return zjfs; }
            set { zjfs = value; }
        }
        /// <summary>
        /// 使用部门
        /// </summary>
        public string Sybm
        {
            get { return sybm; }
            set { sybm = value; }
        }
        /// <summary>
        /// 使用情况
        /// </summary>
        public string Syqk
        {
            get { return syqk; }
            set { syqk = value; }
        }
        /// <summary>
        /// 存放地点
        /// </summary>
        public string Cfdd
        {
            get { return cfdd; }
            set { cfdd = value; }
        }
        /// <summary>
        /// 保管人员
        /// </summary>
        public string Bgry
        {
            get { return bgry; }
            set { bgry = value; }
        }
        /// <summary>
        /// 入账日期
        /// </summary>
        public DateTime Rzrq
        {
            get { return rzrq; }
            set { rzrq = value; }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public int SL
        {
            get { return sl; }
            set { sl = value; }
        }
        /// <summary>
        /// 单位
        /// </summary>
        public string DW
        {
            get { return dw; }
            set { dw = value; }
        }
        /// <summary>
        /// 单价
        /// </summary>
        public float DJ
        {
            get { return dj; }
            set { dj = value; }
        }
        /// <summary>
        /// 原值
        /// </summary>
        public float YZ
        {
            get { return yz; }
            set { yz = value; }
        }
        /// <summary>
        /// 累计折旧
        /// </summary>
        public float Ljzj
        {
            get { return ljzj; }
            set { ljzj = value; }
        }
        /// <summary>
        /// 净值
        /// </summary>
        public float JZ
        {
            get { return jz; }
            set { jz = value; }
        }
        /// <summary>
        /// 净残值率
        /// </summary>
        public float Jczl
        {
            get { return jczl; }
            set { jczl = value; }
        }
        /// <summary>
        /// 折旧方法
        /// </summary>
        public string Zjff
        {
            get { return zjff; }
            set { zjff = value; }
        }
        /// <summary>
        /// 使用年限
        /// </summary>
        public int Nx
        {
            get { return nx; }
            set { nx = value; }
        }
        /// <summary>
        /// 登记日期
        /// </summary>
        public DateTime Login
        {
            get { return login; }
            set { login = value; }
        }
       
        /// <summary>
        /// 登记人
        /// </summary>
        public string Loginer
        {
            get { return loginer; }
            set { loginer = value; }
        }
        private string qlr = "";
        private string qlfs = "";
        private DateTime qlrq = DateTime.Now;
        private string memo = "";
        private string pzr = "";
        /// <summary>
        /// 清理人
        /// </summary>
        public string Qlr
        {
            get { return qlr; }
            set { qlr = value; }
        }
        /// <summary>
        /// 清理方式
        /// </summary>
        public string Qlfs
        {
            get { return qlfs; }
            set { qlfs = value; }
        }
        /// <summary>
        /// 清理日期
        /// </summary>
        public DateTime Qlrq
        {
            get { return qlrq; }
            set { qlrq = value; }
        }
        /// <summary>
        /// 批准人
        /// </summary>
        public string Pzr
        {
            get { return pzr; }
            set { pzr = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo
        {
            get { return memo; }
            set { memo = value; }
        }
    }
    #endregion
}
