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
        #endregion
    }
}
