using Newtonsoft.Json;

namespace GoldenSealWebApi.DTOs
{
    public class MavlinkMessages
    {
        [JsonProperty("PARAM_VALUE", NullValueHandling = NullValueHandling.Ignore)]
        public ParamValue ParamValue { get; set; }

        [JsonProperty("BATTERY2", NullValueHandling = NullValueHandling.Ignore)]
        public Battery2 Battery2 { get; set; }

        [JsonProperty("SYS_STATUS", NullValueHandling = NullValueHandling.Ignore)]
        public SysStatus SysStatus { get; set; }

        [JsonProperty("RAW_IMU", NullValueHandling = NullValueHandling.Ignore)]
        public RawImu RawImu { get; set; }

        [JsonProperty("VIBRATION", NullValueHandling = NullValueHandling.Ignore)]
        public Vibration Vibration { get; set; }

        [JsonProperty("MISSION_CURRENT", NullValueHandling = NullValueHandling.Ignore)]
        public MissionCurrent MissionCurrent { get; set; }

        [JsonProperty("POSITION_TARGET_GLOBAL_INT", NullValueHandling = NullValueHandling.Ignore)]
        public PositionTargetGlobalInt PositionTargetGlobalInt { get; set; }

        [JsonProperty("WIND", NullValueHandling = NullValueHandling.Ignore)]
        public Wind Wind { get; set; }

        [JsonProperty("HOME_POSITION", NullValueHandling = NullValueHandling.Ignore)]
        public HomePosition HomePosition { get; set; }

        [JsonProperty("TIMESYNC", NullValueHandling = NullValueHandling.Ignore)]
        public Timesync Timesync { get; set; }

        [JsonProperty("GLOBAL_POSITION_INT", NullValueHandling = NullValueHandling.Ignore)]
        public GlobalPositionInt GlobalPositionInt { get; set; }

        [JsonProperty("VFR_HUD", NullValueHandling = NullValueHandling.Ignore)]
        public VfrHud VfrHud { get; set; }

        [JsonProperty("AHRS", NullValueHandling = NullValueHandling.Ignore)]
        public Ahrs Ahrs { get; set; }

        [JsonProperty("SCALED_PRESSURE", NullValueHandling = NullValueHandling.Ignore)]
        public ScaledPressure ScaledPressure { get; set; }

        [JsonProperty("BATTERY_STATUS", NullValueHandling = NullValueHandling.Ignore)]
        public BatteryStatus BatteryStatus { get; set; }

        [JsonProperty("AOA_SSA", NullValueHandling = NullValueHandling.Ignore)]
        public AoaSsa AoaSsa { get; set; }

        [JsonProperty("SCALED_IMU3", NullValueHandling = NullValueHandling.Ignore)]
        public RawImu ScaledImu3 { get; set; }

        [JsonProperty("GPS_GLOBAL_ORIGIN", NullValueHandling = NullValueHandling.Ignore)]
        public GpsGlobalOrigin GpsGlobalOrigin { get; set; }

        [JsonProperty("SCALED_IMU2", NullValueHandling = NullValueHandling.Ignore)]
        public RawImu ScaledImu2 { get; set; }

        [JsonProperty("GPS_RAW_INT", NullValueHandling = NullValueHandling.Ignore)]
        public GpsRawInt GpsRawInt { get; set; }

        [JsonProperty("EFI_STATUS", NullValueHandling = NullValueHandling.Ignore)]
        public EfiStatus EfiStatus { get; set; }

        [JsonProperty("EKF_STATUS_REPORT", NullValueHandling = NullValueHandling.Ignore)]
        public EkfStatusReport EkfStatusReport { get; set; }

        [JsonProperty("SYSTEM_TIME", NullValueHandling = NullValueHandling.Ignore)]
        public SystemTime SystemTime { get; set; }

        [JsonProperty("SERVO_OUTPUT_RAW", NullValueHandling = NullValueHandling.Ignore)]
        public ServoOutputRaw ServoOutputRaw { get; set; }

        [JsonProperty("SCALED_PRESSURE2", NullValueHandling = NullValueHandling.Ignore)]
        public ScaledPressure ScaledPressure2 { get; set; }

        [JsonProperty("POWER_STATUS", NullValueHandling = NullValueHandling.Ignore)]
        public PowerStatus PowerStatus { get; set; }

        [JsonProperty("GPS2_RAW", NullValueHandling = NullValueHandling.Ignore)]
        public Gps2Raw Gps2Raw { get; set; }

        [JsonProperty("HEARTBEAT", NullValueHandling = NullValueHandling.Ignore)]
        public Heartbeat Heartbeat { get; set; }

        [JsonProperty("RC_CHANNELS", NullValueHandling = NullValueHandling.Ignore)]
        public RcChannels RcChannels { get; set; }

        [JsonProperty("NAV_CONTROLLER_OUTPUT", NullValueHandling = NullValueHandling.Ignore)]
        public NavControllerOutput NavControllerOutput { get; set; }

        [JsonProperty("MEMINFO", NullValueHandling = NullValueHandling.Ignore)]
        public Meminfo Meminfo { get; set; }

        [JsonProperty("AHRS3", NullValueHandling = NullValueHandling.Ignore)]
        public Ahrs3 Ahrs3 { get; set; }

        [JsonProperty("ATTITUDE", NullValueHandling = NullValueHandling.Ignore)]
        public Attitude Attitude { get; set; }

        [JsonProperty("RPM", NullValueHandling = NullValueHandling.Ignore)]
        public Rpm Rpm { get; set; }

        [JsonProperty("SENSOR_OFFSETS", NullValueHandling = NullValueHandling.Ignore)]
        public SensorOffsets SensorOffsets { get; set; }

        [JsonProperty("AHRS2", NullValueHandling = NullValueHandling.Ignore)]
        public Ahrs2 Ahrs2 { get; set; }

        [JsonProperty("MESSAGE_INTERVAL", NullValueHandling = NullValueHandling.Ignore)]
        public MessageInterval MessageInterval { get; set; }

        [JsonProperty("UAVIONIX_ADSB_TRANSCEIVER_HEALTH_REPORT", NullValueHandling = NullValueHandling.Ignore)]
        public UavionixAdsbTransceiverHealthReport UavionixAdsbTransceiverHealthReport { get; set; }

        [JsonProperty("RADIO_STATUS", NullValueHandling = NullValueHandling.Ignore)]
        public RadioStatus RadioStatus { get; set; }
    }

    public class Ahrs
    {
        [JsonProperty("message")]
        public AhrsMessage Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class AhrsMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("omegaIx")]
        public double OmegaIx { get; set; }

        [JsonProperty("omegaIy")]
        public double OmegaIy { get; set; }

        [JsonProperty("omegaIz")]
        public double OmegaIz { get; set; }

        [JsonProperty("accel_weight")]
        public double AccelWeight { get; set; }

        [JsonProperty("renorm_val")]
        public double RenormVal { get; set; }

        [JsonProperty("error_rp")]
        public double ErrorRp { get; set; }

        [JsonProperty("error_yaw")]
        public double ErrorYaw { get; set; }
    }

    public class Status
    {
        [JsonProperty("time")]
        public Time Time { get; set; }
    }

    public class Time
    {
        [JsonProperty("first_update")]
        public string FirstUpdate { get; set; }

        [JsonProperty("last_update")]
        public string LastUpdate { get; set; }

        [JsonProperty("counter")]
        public long Counter { get; set; }

        [JsonProperty("frequency")]
        public double Frequency { get; set; }
    }

    public class Ahrs2
    {
        [JsonProperty("message")]
        public Ahrs2Message Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class Ahrs2Message
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("roll")]
        public double Roll { get; set; }

        [JsonProperty("pitch")]
        public double Pitch { get; set; }

        [JsonProperty("yaw")]
        public double Yaw { get; set; }

        [JsonProperty("altitude")]
        public double Altitude { get; set; }

        [JsonProperty("lat")]
        public long Lat { get; set; }

        [JsonProperty("lng")]
        public long Lng { get; set; }
    }

    public class Ahrs3
    {
        [JsonProperty("message")]
        public Ahrs3Message Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class Ahrs3Message
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("roll")]
        public double Roll { get; set; }

        [JsonProperty("pitch")]
        public double Pitch { get; set; }

        [JsonProperty("yaw")]
        public double Yaw { get; set; }

        [JsonProperty("altitude")]
        public double Altitude { get; set; }

        [JsonProperty("lat")]
        public long Lat { get; set; }

        [JsonProperty("lng")]
        public long Lng { get; set; }

        [JsonProperty("v1")]
        public double V1 { get; set; }

        [JsonProperty("v2")]
        public double V2 { get; set; }

        [JsonProperty("v3")]
        public double V3 { get; set; }

        [JsonProperty("v4")]
        public double V4 { get; set; }
    }

    public class AoaSsa
    {
        [JsonProperty("message")]
        public AoaSsaMessage Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class AoaSsaMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("time_usec")]
        public long TimeUsec { get; set; }

        [JsonProperty("AOA")]
        public double Aoa { get; set; }

        [JsonProperty("SSA")]
        public double Ssa { get; set; }
    }

    public class Attitude
    {
        [JsonProperty("message")]
        public AttitudeMessage Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class AttitudeMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("time_boot_ms")]
        public long TimeBootMs { get; set; }

        [JsonProperty("roll")]
        public double Roll { get; set; }

        [JsonProperty("pitch")]
        public double Pitch { get; set; }

        [JsonProperty("yaw")]
        public double Yaw { get; set; }

        [JsonProperty("rollspeed")]
        public double Rollspeed { get; set; }

        [JsonProperty("pitchspeed")]
        public double Pitchspeed { get; set; }

        [JsonProperty("yawspeed")]
        public double Yawspeed { get; set; }
    }

    public class Battery2
    {
        [JsonProperty("message")]
        public Battery2Message Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class Battery2Message
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("voltage")]
        public long Voltage { get; set; }

        [JsonProperty("current_battery")]
        public long CurrentBattery { get; set; }
    }

    public class BatteryStatus
    {
        [JsonProperty("message")]
        public BatteryStatusMessage Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class BatteryStatusMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("current_consumed")]
        public long CurrentConsumed { get; set; }

        [JsonProperty("energy_consumed")]
        public long EnergyConsumed { get; set; }

        [JsonProperty("temperature")]
        public long Temperature { get; set; }

        [JsonProperty("voltages")]
        public long[] Voltages { get; set; }

        [JsonProperty("current_battery")]
        public long CurrentBattery { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("battery_function")]
        public BatteryFunction BatteryFunction { get; set; }

        [JsonProperty("mavtype")]
        public BatteryFunction Mavtype { get; set; }

        [JsonProperty("battery_remaining")]
        public long BatteryRemaining { get; set; }

        [JsonProperty("time_remaining")]
        public long TimeRemaining { get; set; }

        [JsonProperty("charge_state")]
        public BatteryFunction ChargeState { get; set; }
    }

    public class BatteryFunction
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class EfiStatus
    {
        [JsonProperty("message")]
        public EfiStatusMessage Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class EfiStatusMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("ecu_index")]
        public double EcuIndex { get; set; }

        [JsonProperty("rpm")]
        public double Rpm { get; set; }

        [JsonProperty("fuel_consumed")]
        public double FuelConsumed { get; set; }

        [JsonProperty("fuel_flow")]
        public double FuelFlow { get; set; }

        [JsonProperty("engine_load")]
        public double EngineLoad { get; set; }

        [JsonProperty("throttle_position")]
        public double ThrottlePosition { get; set; }

        [JsonProperty("spark_dwell_time")]
        public double SparkDwellTime { get; set; }

        [JsonProperty("barometric_pressure")]
        public double BarometricPressure { get; set; }

        [JsonProperty("intake_manifold_pressure")]
        public double IntakeManifoldPressure { get; set; }

        [JsonProperty("intake_manifold_temperature")]
        public double IntakeManifoldTemperature { get; set; }

        [JsonProperty("cylinder_head_temperature")]
        public double CylinderHeadTemperature { get; set; }

        [JsonProperty("ignition_timing")]
        public double IgnitionTiming { get; set; }

        [JsonProperty("injection_time")]
        public double InjectionTime { get; set; }

        [JsonProperty("exhaust_gas_temperature")]
        public double ExhaustGasTemperature { get; set; }

        [JsonProperty("throttle_out")]
        public double ThrottleOut { get; set; }

        [JsonProperty("pt_compensation")]
        public double PtCompensation { get; set; }

        [JsonProperty("health")]
        public long Health { get; set; }
    }

    public class EkfStatusReport
    {
        [JsonProperty("message")]
        public EkfStatusReportMessage Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class EkfStatusReportMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("velocity_variance")]
        public double VelocityVariance { get; set; }

        [JsonProperty("pos_horiz_variance")]
        public double PosHorizVariance { get; set; }

        [JsonProperty("pos_vert_variance")]
        public double PosVertVariance { get; set; }

        [JsonProperty("compass_variance")]
        public double CompassVariance { get; set; }

        [JsonProperty("terrain_alt_variance")]
        public double TerrainAltVariance { get; set; }

        [JsonProperty("flags")]
        public Flags Flags { get; set; }

        [JsonProperty("airspeed_variance")]
        public double AirspeedVariance { get; set; }
    }

    public class Flags
    {
        [JsonProperty("bits")]
        public long Bits { get; set; }
    }

    public class GlobalPositionInt
    {
        [JsonProperty("message")]
        public GlobalPositionIntMessage Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class GlobalPositionIntMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("time_boot_ms")]
        public long TimeBootMs { get; set; }

        [JsonProperty("lat")]
        public long Lat { get; set; }

        [JsonProperty("lon")]
        public long Lon { get; set; }

        [JsonProperty("alt")]
        public long Alt { get; set; }

        [JsonProperty("relative_alt")]
        public long RelativeAlt { get; set; }

        [JsonProperty("vx")]
        public long Vx { get; set; }

        [JsonProperty("vy")]
        public long Vy { get; set; }

        [JsonProperty("vz")]
        public long Vz { get; set; }

        [JsonProperty("hdg")]
        public long Hdg { get; set; }
    }

    public class Gps2Raw
    {
        [JsonProperty("message")]
        public Gps2RawMessage Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class Gps2RawMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("time_usec")]
        public long TimeUsec { get; set; }

        [JsonProperty("lat")]
        public long Lat { get; set; }

        [JsonProperty("lon")]
        public long Lon { get; set; }

        [JsonProperty("alt")]
        public long Alt { get; set; }

        [JsonProperty("dgps_age")]
        public long DgpsAge { get; set; }

        [JsonProperty("eph")]
        public long Eph { get; set; }

        [JsonProperty("epv")]
        public long Epv { get; set; }

        [JsonProperty("vel")]
        public long Vel { get; set; }

        [JsonProperty("cog")]
        public long Cog { get; set; }

        [JsonProperty("fix_type")]
        public BatteryFunction FixType { get; set; }

        [JsonProperty("satellites_visible")]
        public long SatellitesVisible { get; set; }

        [JsonProperty("dgps_numch")]
        public long DgpsNumch { get; set; }

        [JsonProperty("yaw")]
        public long Yaw { get; set; }
    }

    public class GpsGlobalOrigin
    {
        [JsonProperty("message")]
        public GpsGlobalOriginMessage Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class GpsGlobalOriginMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("latitude")]
        public long Latitude { get; set; }

        [JsonProperty("longitude")]
        public long Longitude { get; set; }

        [JsonProperty("altitude")]
        public long Altitude { get; set; }

        [JsonProperty("time_usec")]
        public long TimeUsec { get; set; }
    }

    public class GpsRawInt
    {
        [JsonProperty("message")]
        public GpsRawIntMessage Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class GpsRawIntMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("time_usec")]
        public long TimeUsec { get; set; }

        [JsonProperty("lat")]
        public long Lat { get; set; }

        [JsonProperty("lon")]
        public long Lon { get; set; }

        [JsonProperty("alt")]
        public long Alt { get; set; }

        [JsonProperty("eph")]
        public long Eph { get; set; }

        [JsonProperty("epv")]
        public long Epv { get; set; }

        [JsonProperty("vel")]
        public long Vel { get; set; }

        [JsonProperty("cog")]
        public long Cog { get; set; }

        [JsonProperty("fix_type")]
        public BatteryFunction FixType { get; set; }

        [JsonProperty("satellites_visible")]
        public long SatellitesVisible { get; set; }

        [JsonProperty("alt_ellipsoid")]
        public long AltEllipsoid { get; set; }

        [JsonProperty("h_acc")]
        public long HAcc { get; set; }

        [JsonProperty("v_acc")]
        public long VAcc { get; set; }

        [JsonProperty("vel_acc")]
        public long VelAcc { get; set; }

        [JsonProperty("hdg_acc")]
        public long HdgAcc { get; set; }

        [JsonProperty("yaw")]
        public long Yaw { get; set; }
    }

    public class Heartbeat
    {
        [JsonProperty("message")]
        public HeartbeatMessage Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class HeartbeatMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("custom_mode")]
        public long CustomMode { get; set; }

        [JsonProperty("mavtype")]
        public BatteryFunction Mavtype { get; set; }

        [JsonProperty("autopilot")]
        public BatteryFunction Autopilot { get; set; }

        [JsonProperty("base_mode")]
        public Flags BaseMode { get; set; }

        [JsonProperty("system_status")]
        public BatteryFunction SystemStatus { get; set; }

        [JsonProperty("mavlink_version")]
        public long MavlinkVersion { get; set; }
    }

    public class HomePosition
    {
        [JsonProperty("message")]
        public HomePositionMessage Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class HomePositionMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("latitude")]
        public long Latitude { get; set; }

        [JsonProperty("longitude")]
        public long Longitude { get; set; }

        [JsonProperty("altitude")]
        public long Altitude { get; set; }

        [JsonProperty("x")]
        public double X { get; set; }

        [JsonProperty("y")]
        public double Y { get; set; }

        [JsonProperty("z")]
        public double Z { get; set; }

        [JsonProperty("q")]
        public double[] Q { get; set; }

        [JsonProperty("approach_x")]
        public double ApproachX { get; set; }

        [JsonProperty("approach_y")]
        public double ApproachY { get; set; }

        [JsonProperty("approach_z")]
        public double ApproachZ { get; set; }

        [JsonProperty("time_usec")]
        public long TimeUsec { get; set; }
    }

    public class Meminfo
    {
        [JsonProperty("message")]
        public MeminfoMessage Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class MeminfoMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("brkval")]
        public long Brkval { get; set; }

        [JsonProperty("freemem")]
        public long Freemem { get; set; }

        [JsonProperty("freemem32")]
        public long Freemem32 { get; set; }
    }

    public class MessageInterval
    {
        [JsonProperty("message")]
        public MessageIntervalMessage Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class MessageIntervalMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("interval_us")]
        public long IntervalUs { get; set; }

        [JsonProperty("message_id")]
        public long MessageId { get; set; }
    }

    public class MissionCurrent
    {
        [JsonProperty("message")]
        public MissionCurrentMessage Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class MissionCurrentMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("seq")]
        public long Seq { get; set; }
    }

    public class NavControllerOutput
    {
        [JsonProperty("message")]
        public NavControllerOutputMessage Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class NavControllerOutputMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("nav_roll")]
        public double NavRoll { get; set; }

        [JsonProperty("nav_pitch")]
        public double NavPitch { get; set; }

        [JsonProperty("alt_error")]
        public double AltError { get; set; }

        [JsonProperty("aspd_error")]
        public double AspdError { get; set; }

        [JsonProperty("xtrack_error")]
        public double XtrackError { get; set; }

        [JsonProperty("nav_bearing")]
        public long NavBearing { get; set; }

        [JsonProperty("target_bearing")]
        public long TargetBearing { get; set; }

        [JsonProperty("wp_dist")]
        public long WpDist { get; set; }
    }

    public class ParamValue
    {
        [JsonProperty("message")]
        public ParamValueMessage Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class ParamValueMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("param_value")]
        public double ParamValue { get; set; }

        [JsonProperty("param_count")]
        public long ParamCount { get; set; }

        [JsonProperty("param_index")]
        public long ParamIndex { get; set; }

        [JsonProperty("param_id")]
        public string[] ParamId { get; set; }

        [JsonProperty("param_type")]
        public BatteryFunction ParamType { get; set; }
    }

    public class PositionTargetGlobalInt
    {
        [JsonProperty("message")]
        public PositionTargetGlobalIntMessage Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class PositionTargetGlobalIntMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("time_boot_ms")]
        public long TimeBootMs { get; set; }

        [JsonProperty("lat_int")]
        public long LatInt { get; set; }

        [JsonProperty("lon_int")]
        public long LonInt { get; set; }

        [JsonProperty("alt")]
        public double Alt { get; set; }

        [JsonProperty("vx")]
        public double Vx { get; set; }

        [JsonProperty("vy")]
        public double Vy { get; set; }

        [JsonProperty("vz")]
        public double Vz { get; set; }

        [JsonProperty("afx")]
        public double Afx { get; set; }

        [JsonProperty("afy")]
        public double Afy { get; set; }

        [JsonProperty("afz")]
        public double Afz { get; set; }

        [JsonProperty("yaw")]
        public double Yaw { get; set; }

        [JsonProperty("yaw_rate")]
        public double YawRate { get; set; }

        [JsonProperty("type_mask")]
        public Flags TypeMask { get; set; }

        [JsonProperty("coordinate_frame")]
        public BatteryFunction CoordinateFrame { get; set; }
    }

    public class PowerStatus
    {
        [JsonProperty("message")]
        public PowerStatusMessage Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class PowerStatusMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("Vcc")]
        public long Vcc { get; set; }

        [JsonProperty("Vservo")]
        public long Vservo { get; set; }

        [JsonProperty("flags")]
        public Flags Flags { get; set; }
    }

    public class RadioStatus
    {
        [JsonProperty("message")]
        public RadioStatusMessage Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class RadioStatusMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("rxerrors")]
        public long Rxerrors { get; set; }

        [JsonProperty("fixed")]
        public long Fixed { get; set; }

        [JsonProperty("rssi")]
        public long Rssi { get; set; }

        [JsonProperty("remrssi")]
        public long Remrssi { get; set; }

        [JsonProperty("txbuf")]
        public long Txbuf { get; set; }

        [JsonProperty("noise")]
        public long Noise { get; set; }

        [JsonProperty("remnoise")]
        public long Remnoise { get; set; }
    }

    public class RawImu
    {
        [JsonProperty("message")]
        public RawImuMessage Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class RawImuMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("time_usec", NullValueHandling = NullValueHandling.Ignore)]
        public long? TimeUsec { get; set; }

        [JsonProperty("xacc")]
        public long Xacc { get; set; }

        [JsonProperty("yacc")]
        public long Yacc { get; set; }

        [JsonProperty("zacc")]
        public long Zacc { get; set; }

        [JsonProperty("xgyro")]
        public long Xgyro { get; set; }

        [JsonProperty("ygyro")]
        public long Ygyro { get; set; }

        [JsonProperty("zgyro")]
        public long Zgyro { get; set; }

        [JsonProperty("xmag")]
        public long Xmag { get; set; }

        [JsonProperty("ymag")]
        public long Ymag { get; set; }

        [JsonProperty("zmag")]
        public long Zmag { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("temperature")]
        public long Temperature { get; set; }

        [JsonProperty("time_boot_ms", NullValueHandling = NullValueHandling.Ignore)]
        public long? TimeBootMs { get; set; }
    }

    public class RcChannels
    {
        [JsonProperty("message")]
        public RcChannelsMessage Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class RcChannelsMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("time_boot_ms")]
        public long TimeBootMs { get; set; }

        [JsonProperty("chan1_raw")]
        public long Chan1Raw { get; set; }

        [JsonProperty("chan2_raw")]
        public long Chan2Raw { get; set; }

        [JsonProperty("chan3_raw")]
        public long Chan3Raw { get; set; }

        [JsonProperty("chan4_raw")]
        public long Chan4Raw { get; set; }

        [JsonProperty("chan5_raw")]
        public long Chan5Raw { get; set; }

        [JsonProperty("chan6_raw")]
        public long Chan6Raw { get; set; }

        [JsonProperty("chan7_raw")]
        public long Chan7Raw { get; set; }

        [JsonProperty("chan8_raw")]
        public long Chan8Raw { get; set; }

        [JsonProperty("chan9_raw")]
        public long Chan9Raw { get; set; }

        [JsonProperty("chan10_raw")]
        public long Chan10Raw { get; set; }

        [JsonProperty("chan11_raw")]
        public long Chan11Raw { get; set; }

        [JsonProperty("chan12_raw")]
        public long Chan12Raw { get; set; }

        [JsonProperty("chan13_raw")]
        public long Chan13Raw { get; set; }

        [JsonProperty("chan14_raw")]
        public long Chan14Raw { get; set; }

        [JsonProperty("chan15_raw")]
        public long Chan15Raw { get; set; }

        [JsonProperty("chan16_raw")]
        public long Chan16Raw { get; set; }

        [JsonProperty("chan17_raw")]
        public long Chan17Raw { get; set; }

        [JsonProperty("chan18_raw")]
        public long Chan18Raw { get; set; }

        [JsonProperty("chancount")]
        public long Chancount { get; set; }

        [JsonProperty("rssi")]
        public long Rssi { get; set; }
    }

    public class Rpm
    {
        [JsonProperty("message")]
        public RpmMessage Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class RpmMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("rpm1")]
        public double Rpm1 { get; set; }

        [JsonProperty("rpm2")]
        public double Rpm2 { get; set; }
    }

    public class ScaledPressure
    {
        [JsonProperty("message")]
        public ScaledPressureMessage Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class ScaledPressureMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("time_boot_ms")]
        public long TimeBootMs { get; set; }

        [JsonProperty("press_abs")]
        public double PressAbs { get; set; }

        [JsonProperty("press_diff")]
        public double PressDiff { get; set; }

        [JsonProperty("temperature")]
        public long Temperature { get; set; }
    }

    public class SensorOffsets
    {
        [JsonProperty("message")]
        public SensorOffsetsMessage Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class SensorOffsetsMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("mag_declination")]
        public double MagDeclination { get; set; }

        [JsonProperty("raw_press")]
        public long RawPress { get; set; }

        [JsonProperty("raw_temp")]
        public long RawTemp { get; set; }

        [JsonProperty("gyro_cal_x")]
        public double GyroCalX { get; set; }

        [JsonProperty("gyro_cal_y")]
        public double GyroCalY { get; set; }

        [JsonProperty("gyro_cal_z")]
        public double GyroCalZ { get; set; }

        [JsonProperty("accel_cal_x")]
        public double AccelCalX { get; set; }

        [JsonProperty("accel_cal_y")]
        public double AccelCalY { get; set; }

        [JsonProperty("accel_cal_z")]
        public double AccelCalZ { get; set; }

        [JsonProperty("mag_ofs_x")]
        public long MagOfsX { get; set; }

        [JsonProperty("mag_ofs_y")]
        public long MagOfsY { get; set; }

        [JsonProperty("mag_ofs_z")]
        public long MagOfsZ { get; set; }
    }

    public class ServoOutputRaw
    {
        [JsonProperty("message")]
        public ServoOutputRawMessage Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class ServoOutputRawMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("time_usec")]
        public long TimeUsec { get; set; }

        [JsonProperty("servo1_raw")]
        public long Servo1Raw { get; set; }

        [JsonProperty("servo2_raw")]
        public long Servo2Raw { get; set; }

        [JsonProperty("servo3_raw")]
        public long Servo3Raw { get; set; }

        [JsonProperty("servo4_raw")]
        public long Servo4Raw { get; set; }

        [JsonProperty("servo5_raw")]
        public long Servo5Raw { get; set; }

        [JsonProperty("servo6_raw")]
        public long Servo6Raw { get; set; }

        [JsonProperty("servo7_raw")]
        public long Servo7Raw { get; set; }

        [JsonProperty("servo8_raw")]
        public long Servo8Raw { get; set; }

        [JsonProperty("port")]
        public long Port { get; set; }

        [JsonProperty("servo9_raw")]
        public long Servo9Raw { get; set; }

        [JsonProperty("servo10_raw")]
        public long Servo10Raw { get; set; }

        [JsonProperty("servo11_raw")]
        public long Servo11Raw { get; set; }

        [JsonProperty("servo12_raw")]
        public long Servo12Raw { get; set; }

        [JsonProperty("servo13_raw")]
        public long Servo13Raw { get; set; }

        [JsonProperty("servo14_raw")]
        public long Servo14Raw { get; set; }

        [JsonProperty("servo15_raw")]
        public long Servo15Raw { get; set; }

        [JsonProperty("servo16_raw")]
        public long Servo16Raw { get; set; }
    }

    public class SysStatus
    {
        [JsonProperty("message")]
        public SysStatusMessage Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class SysStatusMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("onboard_control_sensors_present")]
        public Flags OnboardControlSensorsPresent { get; set; }

        [JsonProperty("onboard_control_sensors_enabled")]
        public Flags OnboardControlSensorsEnabled { get; set; }

        [JsonProperty("onboard_control_sensors_health")]
        public Flags OnboardControlSensorsHealth { get; set; }

        [JsonProperty("load")]
        public long Load { get; set; }

        [JsonProperty("voltage_battery")]
        public long VoltageBattery { get; set; }

        [JsonProperty("current_battery")]
        public long CurrentBattery { get; set; }

        [JsonProperty("drop_rate_comm")]
        public long DropRateComm { get; set; }

        [JsonProperty("errors_comm")]
        public long ErrorsComm { get; set; }

        [JsonProperty("errors_count1")]
        public long ErrorsCount1 { get; set; }

        [JsonProperty("errors_count2")]
        public long ErrorsCount2 { get; set; }

        [JsonProperty("errors_count3")]
        public long ErrorsCount3 { get; set; }

        [JsonProperty("errors_count4")]
        public long ErrorsCount4 { get; set; }

        [JsonProperty("battery_remaining")]
        public long BatteryRemaining { get; set; }
    }

    public class SystemTime
    {
        [JsonProperty("message")]
        public SystemTimeMessage Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class SystemTimeMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("time_unix_usec")]
        public long TimeUnixUsec { get; set; }

        [JsonProperty("time_boot_ms")]
        public long TimeBootMs { get; set; }
    }

    public class Timesync
    {
        [JsonProperty("message")]
        public TimesyncMessage Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class TimesyncMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("tc1")]
        public long Tc1 { get; set; }

        [JsonProperty("ts1")]
        public long Ts1 { get; set; }
    }

    public class UavionixAdsbTransceiverHealthReport
    {
        [JsonProperty("message")]
        public UavionixAdsbTransceiverHealthReportMessage Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class UavionixAdsbTransceiverHealthReportMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("rfHealth")]
        public Flags RfHealth { get; set; }
    }

    public class VfrHud
    {
        [JsonProperty("message")]
        public VfrHudMessage Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class VfrHudMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("airspeed")]
        public double Airspeed { get; set; }

        [JsonProperty("groundspeed")]
        public double Groundspeed { get; set; }

        [JsonProperty("alt")]
        public double Alt { get; set; }

        [JsonProperty("climb")]
        public double Climb { get; set; }

        [JsonProperty("heading")]
        public long Heading { get; set; }

        [JsonProperty("throttle")]
        public long Throttle { get; set; }
    }

    public class Vibration
    {
        [JsonProperty("message")]
        public VibrationMessage Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class VibrationMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("time_usec")]
        public long TimeUsec { get; set; }

        [JsonProperty("vibration_x")]
        public double VibrationX { get; set; }

        [JsonProperty("vibration_y")]
        public double VibrationY { get; set; }

        [JsonProperty("vibration_z")]
        public double VibrationZ { get; set; }

        [JsonProperty("clipping_0")]
        public long Clipping0 { get; set; }

        [JsonProperty("clipping_1")]
        public long Clipping1 { get; set; }

        [JsonProperty("clipping_2")]
        public long Clipping2 { get; set; }
    }

    public class Wind
    {
        [JsonProperty("message")]
        public WindMessage Message { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class WindMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("direction")]
        public double Direction { get; set; }

        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("speed_z")]
        public double SpeedZ { get; set; }
    }
}
