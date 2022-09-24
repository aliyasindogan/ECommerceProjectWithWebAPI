using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Messages
{
    public enum ResultCodes
    {
        #region ERROR
        /// <summary>
        /// Kullanıcı Bulunamadı! 
        /// </summary>
        ERROR_UserNotFound = -20_001,
        #endregion
        #region INFO
        /// <summary>
        /// Kullanıcı başarıyla kaydedildi.
        /// </summary>
        INFO_UserRegistered = 1,

        #endregion

        #region VALIDATION
        /// <summary>
        /// Kullanıcı adı alanı boş geçilemez!
        /// </summary>
        VALIDATION_UserNameFieldCannotBeEmpty = -3001,
        #endregion

        #region LABEL
        /// <summary>
        /// Kullanıcı Adı
        /// </summary>
        LABEL_UserName = 7000,
        LABEL_AppUserTypeName=7001,
        LABEL_ProfileImageUrl = 7002,
        LABEL_FirstName = 7003,
        LABEL_LastName = 7004,
        LABEL_Operations=7005,
        LABEL_AppUserList = 7006,
        LABEL_AppUserAdd = 7007,
        LABEL_AppUserUpdate = 7008,
        LABEL_AppUserDelete = 7009,
        LABEL_AppUserDetail = 7010,
        LABEL_SignOut = 7011,

        #endregion
    }
}
