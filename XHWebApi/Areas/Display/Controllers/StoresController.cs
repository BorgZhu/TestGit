using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using System.Data;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using XHWebApi_BLL;
using XHWebApi_Common;
using XHWebApi_Model;
using Newtonsoft.Json.Linq;
using XHWebApi;

namespace XHWebApp.Areas.Trading.Controllers
{
    public class StoresController : ApiController
    {
    
        #region 测试get返回字符串
        /// <summary>
        /// 注意：字符串json格式必须先把“字符串json格式数据”转化为Object对象
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Query()
        {
            var sp = new XHWebApi_BLL.Stores();

            return Ok(sp.GetFirstPage(null));
        }
        #endregion

       
        [HttpPost]
        public IHttpActionResult Query([FromBody]JObject para)
        {
            var sp = new XHWebApi_BLL.Stores();
            try
            {
               return Ok(sp.GetFirstPage(para));
            }
            catch (Exception e)
            {
                var strpara = "";
                try
                {
                    strpara += para.ToString();
                }
                catch (Exception e1)
                {
                    strpara += e1.Message;
                }
                return Ok(ReturnJsonResult.GetJsonResult(0, "查询失败",  e.Message));

            }

        }

        //
        [HttpPost]
        public IHttpActionResult Save([FromBody]JObject para)
        {
            var sp = new XHWebApi_BLL.Stores();
            try
            {
                var ret = sp.Save(para);
                return Ok(ReturnJsonResult.GetJsonResult(ret.ToString() == "1" ? 1 : 0, ret.ToString() =="1"?"保存成功": "保存失败", ret));
            }
            catch (Exception e)
            {
             
                return Ok(ReturnJsonResult.GetJsonResult(0, "保存失败", e.Message));

            }

        }

        [HttpPost]
        public IHttpActionResult Del([FromBody]JObject para)
        {
           
            var sp = new XHWebApi_BLL.Stores();
            try
            {
                return Ok(ReturnJsonResult.GetJsonResult(1, "删除成功", sp.Del(para)));
            }
            catch (Exception e)
            {

                return Ok(ReturnJsonResult.GetJsonResult(0, "删除失败", e.Message));

            }

        }
    }
}
