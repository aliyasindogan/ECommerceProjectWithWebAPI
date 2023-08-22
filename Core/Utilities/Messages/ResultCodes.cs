namespace Core.Utilities.Messages
{
    public enum ResultCodes
    {
        #region HTTP Status Code
        HTTP_OK = 200,
        HTTP_InternalServerError = 500,
        HTTP_BadRequest = 400,
        HTTP_Unauthorized = 401,
        HTTP_Forbidden = 403,
        HTTP_NotFound = 404,
        HTTP_Conflict = 409,
        #endregion
        #region ERROR
        /// <summary>
        /// Kullanıcı Bulunamadı! 
        /// </summary>
        ERROR_UserNotFound = -20001,
        /// <summary>
        /// Resim mevcut değil!
        /// </summary>
        ERROR_ImageNotFound = -20002,

        /// <summary>
        /// Ekleme işlemi başarısız
        /// </summary>
        ERROR_NoAdded = -20003,

        /// <summary>
        /// Silme işlemi başarısız
        /// </summary>
        ERROR_NotDeleted = -20004,

        /// <summary>
        /// Düzenleme işlemi başarısız
        /// </summary>
        ERROR_NotUpdated = -20005,
        /// <summary>
        /// HATA!
        /// </summary>
        ERROR_Error=-20006,
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
        /// <summary>
        /// Bu kayıt zaten var!
        /// </summary>
        VALIDATION_ThisRecordAlreadyExists = -3002,
        #endregion

        #region LABEL
        /// <summary>
        /// Kullanıcı Adı
        /// </summary>
        LABEL_UserName = 7000,
        LABEL_AppUserTypeName = 7001,
        LABEL_ProfileImageUrl = 7002,
        LABEL_FirstName = 7003,
        LABEL_LastName = 7004,
        LABEL_Operations = 7005,

        LABEL_GsmNumber = 7006,
        LABEL_Email = 7007,
        LABEL_Password = 7008,
        LABEL_AreYouSureYouWantToDelete = 7009,
        LABEL_AppUserType = 7010,
        LABEL_Choose      =7011,
        #endregion

        #region BUTTON
        BUTTON_Add = 9000,
        BUTTON_Update = 9001,
        BUTTON_Delete = 9002,
        BUTTON_Detail = 9003,
        BUTTON_SignOut = 9004,
        BUTTON_AppUserList = 9005,
        BUTTON_Save = 90006,
        BUTTON_AppUserTypeList= 90007,
        #endregion

        #region PAGETITLE
        PAGETITLE_AppUserList = 8000,
        PAGETITLE_AppUserAdd = 8001,
        PAGETITLE_AppUserUpdate = 8002,
        PAGETITLE_AppUserDelete = 8003,
        PAGETITLE_AppUserDetail = 8004,

        PAGETITLE_AppUserTypeList = 8005,
        PAGETITLE_AppUserTypeAdd = 8006,
        PAGETITLE_AppUserTypeUpdate = 8007,
        PAGETITLE_AppUserTypeDelete = 8008,
        PAGETITLE_AppUserTypeDetail = 8009,

        PAGETITLE_PageList=8010,
        PAGETITLE_PageAdd = 8011,
        PAGETITLE_PageUpdate = 8012,
        PAGETITLE_PageDelete = 8013,
        PAGETITLE_PageDetail = 8014,
        #endregion
    }
}
