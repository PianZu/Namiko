﻿using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace Victoria.Payloads {
    /// <summary>
    ///     Equalizer band
    /// </summary>
    public struct EqualizerBand : IEquatable<EqualizerBand> {
        /// <summary>
        ///     15 bands (0-14) that can be changed.
        /// </summary>
        [JsonPropertyName("band")]
        public ushort Band { get; }

        /// <summary>
        ///     Gain is the multiplier for the given band. The default value is 0. Valid values range from -0.25 to 1.0,
        ///     where -0.25 means the given band is completely muted, and 0.25 means it is doubled.
        /// </summary>
        [JsonPropertyName("gain")]
        public double Gain { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="band"></param>
        /// <param name="gain"></param>
        public EqualizerBand(ushort band, double gain) {
            if (!Enumerable.Range(0, 14).Contains(band))
                throw new ArgumentOutOfRangeException(nameof(band), "Valid bands are from 0 - 14.");

            if (gain < -0.25 || gain > 1.0)
                throw new ArgumentOutOfRangeException(nameof(gain), "Valid gains are from -0.25 - 1.0.");

            Band = band;
            Gain = gain;
        }

        /// <inheritdoc />
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public override bool Equals(object? obj)
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        {

            if (obj == null || !(obj is EqualizerBand equalizerBand))
                return false;

            return equalizerBand.Band == Band;
        }

        /// <inheritdoc />
        public bool Equals(EqualizerBand other) {
            return Band == other.Band;
        }

        /// <inheritdoc />
        public override int GetHashCode() {
            unchecked {
                return (Band.GetHashCode() * 397) ^ Gain.GetHashCode();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(EqualizerBand left, EqualizerBand right) {
            return left.Equals(right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(EqualizerBand left, EqualizerBand right) {
            return !left.Equals(right);
        }
    }
}