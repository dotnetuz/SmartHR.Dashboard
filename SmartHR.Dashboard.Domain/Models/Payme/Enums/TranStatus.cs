namespace Taqsim.Services.Admin.Domain.Enums
{
    public enum TranStatus
    {
        /// <summary>
        /// Created
        /// </summary>
        /// <uz>Yaratilgan</uz>
        /// <ru>Создан</ru>
        /// <en>Created</en>
        Created = 0,

        /// <summary>
        /// Success
        /// </summary>
        /// <uz>Muvaffaqiyatli</uz>
        /// <ru>successfully</ru>
        /// <en>Успешно</en>
        Success = 1,

        /// <summary>
        /// Error
        /// </summary>
        /// <uz>Xato</uz>
        /// <ru>Ошибка</ru>
        /// <en>Error</en>
        Error = 2,

        /// <summary>
        /// Cancelled
        /// </summary>
        /// <uz>Bekor qilingan</uz>
        /// <ru>Отменен</ru>
        /// <en>Cancelled</en>
        Cancelled = 3,

        /// <summary>
        /// Cancelled
        /// </summary>
        /// <uz>Bekor qilingan</uz>
        /// <ru>Отменен</ru>
        /// <en>Cancelled</en>
        CancelledByOwner = 4,

        /// <summary>
        /// Cancelled
        /// </summary>
        /// <uz>Bekor qilingan</uz>
        /// <ru>Отменен</ru>
        /// <en>Cancelled</en>
        CancelledByAdmin = 5,

        /// <summary>
        /// Error
        /// </summary>
        /// <uz>Xato</uz>
        /// <ru>Ошибка</ru>
        /// <en>Error</en>
        SvGateError = 6,

        /// <summary>
        /// NeedToCancel
        /// </summary>
        /// <uz>Bekor qilinishi kerak</uz>
        /// <ru>Нужно отменить</ru>
        /// <en>Need to cancel</en>
        NeedToCancel = 7,

        /// <summary>
        /// NeedToCancel
        /// </summary>
        /// <uz>Bekor qilinishi kerak</uz>
        /// <ru>Нужно отменить</ru>
        /// <en>Need to cancel</en>
        NeedToExtCancel = 8,

        /// <summary>
        /// SvGateSuccess
        /// </summary>
        /// <uz>Muvaffaqiyatli</uz>
        /// <ru>Успешно</ru>
        /// <en>Successfully</en>
        SvGateSuccess = 9,

        /// <summary>
        /// SvGateSuccess
        /// </summary>
        /// <uz>Muvaffaqiyatli</uz>
        /// <ru>Успешно</ru>
        /// <en>Successfully</en>
        Held = 10,

    }
}