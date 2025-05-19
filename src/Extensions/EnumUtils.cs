namespace Roblox.Common;

using System;
using System.ComponentModel;

/// <summary>
/// The enum utilities.
/// </summary>
public static class EnumUtils
{
    /// <summary>
    /// Get the description of the enum if <see cref="DescriptionAttribute"/> is present.
    /// </summary>
    /// <param name="value">The enum value.</param>
    /// <returns>The description of the enum or the enum value as a string.</returns>
    public static string ToDescription(this Enum value)
    {
        var description = value.GetType().GetField(value.ToString())?.GetCustomAttributes(typeof(DescriptionAttribute), false);
        if (description != null && description.Length > 0)
            return ((DescriptionAttribute)description[0]).Description;

        return value.ToString();
    }

    /// <summary>
    /// Strictly parses an enum value.
    /// </summary>
    /// <typeparam name="TEnum">The enum type.</typeparam>
    /// <param name="value">The value.</param>
    /// <returns>The enum value.</returns>
    public static TEnum? StrictTryParseEnum<TEnum>(this string value)
        where TEnum : struct
    {
        if (Enum.TryParse<TEnum>(value, out var @enum) && Enum.IsDefined(typeof(TEnum), @enum))
            return @enum;

        return null;
    }
}
