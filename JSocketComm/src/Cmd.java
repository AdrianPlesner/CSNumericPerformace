import java.util.EnumSet;
import java.util.HashMap;
import java.util.Map;

public enum Cmd {
    Unkown(-3),
    Error(-2),
    Stopped(-1),
    Exit(0),
    Go(1),
    Done(2),
    Ready(3),
    Ok(4);
    private static final Map<Integer, Cmd> VALUE_TO_ENUM_MAP;
    private final int value;

    static {
        VALUE_TO_ENUM_MAP = new HashMap<>();
        for (Cmd type : EnumSet.allOf(Cmd.class)) {
            VALUE_TO_ENUM_MAP.put(type.value, type);
        }
    }

    private Cmd(int value) {
        this.value = value;
    }

    public int getValue() {
        return value;
    }

    public static Cmd forValue(int value) {
        return VALUE_TO_ENUM_MAP.get(value);
    }

}
