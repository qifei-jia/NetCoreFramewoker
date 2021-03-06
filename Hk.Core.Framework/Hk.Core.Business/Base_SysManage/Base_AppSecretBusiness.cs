﻿using Hk.Core.Business.BaseBusiness;
using Hk.Core.Entity.Base_SysManage;
using Hk.Core.Util.Datas;
using Hk.Core.Util.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using Hk.Core.Data.DbContextCore;
using Hk.Core.IRepositorys;
using Hk.Core.Util.Helper;

namespace Hk.Core.Business.Base_SysManage
{
    public class Base_AppSecretBusiness : BaseBusiness<Base_AppSecret,string>
    {
        private IBasePermissionAppIdRepository _appIdRepository;
        public Base_AppSecretBusiness(IDbContextCore dbContext) : base(dbContext)
        {
            _appIdRepository = Ioc.DefaultContainer.GetService<IBasePermissionAppIdRepository>();
        }
        #region 外部接口

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="condition">查询类型</param>
        /// <param name="keyword">关键字</param>
        /// <returns></returns>
        public List<Base_AppSecret> GetDataList(string condition, string keyword, Pagination pagination)
        {
            var q = Get();

            //模糊查询
            if (!condition.IsNullOrEmpty() && !keyword.IsNullOrEmpty())
                q = q.Where($@"{condition}.Contains(@0)", keyword);

            return q.GetPagination(pagination).ToList();
        }

        /// <summary>
        /// 获取指定的单条数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public Base_AppSecret GetTheData(string id)
        {
            return GetSingle(id);
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="newData">数据</param>
        public void AddData(Base_AppSecret newData)
        {
            Add(newData);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        public void UpdateData(Base_AppSecret theData)
        {
            Update(theData);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="theData">删除的数据</param>
        public void DeleteData(List<string> ids)
        {
            ids.ForEach(x=>Delete(x));
        }

        /// <summary>
        /// 保存权限
        /// </summary>
        /// <param name="appId">应用Id</param>
        /// <param name="permissions">权限值</param>
        public void SavePermission(string appId, List<string> permissions)
        {
            _appIdRepository.Delete(x => x.AppId == appId);

            List<Base_PermissionAppId> insertList = new List<Base_PermissionAppId>();
            permissions.ForEach(newPermission =>
            {
                insertList.Add(new Base_PermissionAppId
                {
                    AppId = appId,
                    PermissionValue = newPermission
                });
            });

            _appIdRepository.AddRange(insertList);
        }

        #endregion

        #region 私有成员

        #endregion

        #region 数据模型

        #endregion

    }
}