using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashalotPRRO.Model
{
    /// <summary>
    /// Клас документа
    /// </summary>
    public enum DocumentClass
    {
        /// <summary>
        /// Чек
        /// </summary>
        Check = 0,
        /// <summary>
        /// Z-звіт
        /// </summary>
        ZRep = 1
    }

    /// <summary>
    /// Чек. Тип документа
    /// </summary>
    public enum CheckDocumentType
    {
        /// <summary>
        /// Чек реалізації товарів/послуг
        /// </summary>
        SaleGoods = 0,
        /// <summary>
        /// Чек переказу коштів
        /// </summary>
        TransferFunds = 1,
        /// <summary>
        /// Чек операції обміну валюти
        /// </summary>
        CurrencyExchange = 2,
        /// <summary>
        /// Чек видачі готівки
        /// </summary>
        CashWithdrawal = 3,
        /// <summary>
        /// Чек обслуговування у ломбарді
        /// </summary>
        Pawnshop = 4,
        /// <summary>
        /// Відкриття зміни
        /// </summary>
        OpenShift = 100,
        /// <summary>
        /// Закриття зміни
        /// </summary>
        CloseShift = 101,
        /// <summary>
        /// Початок офлайн сесії
        /// </summary>
        OfflineBegin = 102,
        /// <summary>
        /// Завершення офлайн сесії
        /// </summary>
        OfflineEnd = 103
    }

    /// <summary>
    /// Чек. Розширений тип документа
    /// </summary>
    public enum CheckDocumentSubType
    {
        /// <summary>
        /// Касовий чек (реалізація)
        /// </summary>
        CheckGoods = 0,
        /// <summary>
        /// Видатковий чек (повернення)
        /// </summary>
        CheckReturn = 1,
        /// <summary>
        /// Чек операції «службове внесення»/«отримання авансу»
        /// </summary>
        ServiceDeposit = 2,
        /// <summary>
        /// Чек операції «отримання підкріплення»
        /// </summary>
        AdditionalDeposit = 3,
        /// <summary>
        /// Чек операції «службова видача»/«інкасація»
        /// </summary>
        ServiceIssue = 4,
        /// <summary>
        /// Чек сторнування попереднього чека
        /// </summary>
        CheckStorno = 5
    }

    /// <summary>
    /// Тип часткової сплати
    /// </summary>
    public enum PartialPaymentType
    {
        /// <summary>
        /// Передплата
        /// </summary>
        Prepay = 1,
        /// <summary>
        /// Остаточний розрахунок
        /// </summary>
        FinalPayment = 2,
        /// <summary>
        /// Чергова сплата
        /// </summary>
        NextPayment = 3
    }

    /// <summary>
    /// Тип даних запита документа
    /// </summary>
    public enum DocumentRequestType
    {
        /// <summary>
        /// Перевірка наявності документа
        /// </summary>
        Availability = 0,
        /// <summary>
        /// Оригінальний XML
        /// </summary>
        OriginalXml = 1,
        /// <summary>
        /// XML засвідчений КЕП Фіскального Сервера
        /// </summary>
        SignedByServerXml = 2,
        /// <summary>
        /// Документ в текстовому форматі для відображення (UTF-8)
        /// </summary>
        Visualization = 3,
        /// <summary>
        /// XML засвідчений КЕП відправника
        /// </summary>
        SignedBySenderXml = 4,
        /// <summary>
        /// XML засвідчений КЕП відправника і КЕП Фіскального Сервера
        /// </summary>
        SignedBySenderAndServerXml = 5
    }

    /// <summary>
    /// Режим роботи ПРРО
    /// </summary>
    public enum RegistrarWorkMode
    {
        /// <summary>
        /// Звичайний
        /// </summary>
        Normal = 0,
        /// <summary>
        /// Режим онлайн заборонений
        /// </summary>
        DisableOnline = 1,
        /// <summary>
        /// Режим офлайн заборонений
        /// </summary>
        DisableOffline = 2
    }

    /// <summary>
    /// Код результату обробки запиту документа
    /// </summary>
    public enum DocumentRequestResultCode
    {
        /// <summary>
        /// OK
        /// </summary>
        Ok = 0,
        /// <summary>
        /// Документ з фіскальним номером, що відповідає режиму онлайн, не зареєстрований на ПРРО
        /// </summary>
        OnlineDocumentAbsent = 1,
        /// <summary>
        /// Фіскальний номер зарезервований для використання в режимі офлайн на ПРРО, але наразі ще не переданий з ПРРО до контролюючого органу
        /// </summary>
        OfflineNumberReserved = 2,
        /// <summary>
        /// Фіскальний номер не зарезервований для використання в режимі офлайн на ПРРО
        /// </summary>
        OfflineNumberNotReserved = 3,
        /// <summary>
        /// ПРРО не зареєстрований
        /// </summary>
        TransactionsRegistrarNotRegistered = 4
    }
}


