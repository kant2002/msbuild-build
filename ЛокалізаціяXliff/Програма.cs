using ЛокалізаціяXliff;

Консоль.НадрукуватиРядок(ГлобальніРядки.ПривітСвіт);

#region Встановити українську культуру для потока
Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("uk");
#endregion

Консоль.НадрукуватиРядок(ГлобальніРядки.ПривітСвіт);
