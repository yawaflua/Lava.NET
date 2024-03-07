using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lava.NET.Types.Enums
{
    public enum ErrorCode
    {
        /// <summary>Неизвестная ошибка</summary>
        UnknownError = 0,
        /// <summary>Объект не найден</summary>
        ObjectNotFound = 1,
        /// <summary>Неверное значение параметра</summary>
        InvalidParameterValue = 2,
        /// <summary>Неверный JWT-токен</summary>
        InvalidJWTToken = 5,
        /// <summary>Серверная ошибка</summary>
        ServerError = 6,
        /// <summary>Неверный тип запроса</summary>
        InvalidRequestType = 7,
        /// <summary>Переданы неверный параметры</summary>
        InvalidParameters = 100,
        /// <summary>Неверный номер счета</summary>
        InvalidInvoiceNumber = 101,
        /// <summary>Сумма меньше минимальной</summary>
        AmountBelowMinimum = 102,
        /// <summary>Сумма больше максимальной</summary>
        AmountAboveMaximum = 103,
        /// <summary>Недостаточно средств на балансе</summary>
        InsufficientBalance = 104,
        /// <summary>Транзакция не найдена</summary>
        TransactionNotFound = 105,
        /// <summary>Перевод недоступен</summary>
        TransferUnavailable = 107,
        /// <summary>Время жизни меньше минимальной</summary>
        ExpireBelowMinimum = 202,
        /// <summary>Время жизни больше максимальной</summary>
        ExpireAboveMaximum = 203,
        /// <summary>Номер больше 255 символов</summary>
        OrderNumberTooLong = 204,
        /// <summary>Такой номер заказа уже существует</summary>
        OrderNumberAlreadyExists = 205,
        /// <summary>Счет на оплату не найден</summary>
        InvoiceNotFound = 206,
        /// <summary>Срок жизни счета истек</summary>
        InvoiceExpired = 207,
        /// <summary>Счет уже оплачен</summary>
        InvoiceAlreadyPaid = 208,
        /// <summary>Не установлен секретный ключ</summary>
        SecretKeyNotSet = 209,
        /// <summary>Неверная сигнатура</summary>
        InvalidSignature = 210,
        /// <summary>Конвертация недоступна</summary>
        ConversionUnavailable = 251
    }

}
