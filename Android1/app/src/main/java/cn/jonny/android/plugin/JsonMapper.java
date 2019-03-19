package cn.jonny.android.plugin;

import com.google.gson.Gson;

public class JsonMapper {
    private static final long serialVersionUID = 1L;
    private static Gson mapper;
    private static Gson gson;

    public JsonMapper() {
    }

    public static Gson getInstance() {
        if (gson == null) {
            gson = new Gson();
        }

        return gson;
    }

    public static Gson nonDefaultMapper() {
        if (mapper == null) {
            mapper = new Gson();
        }

        return mapper;
    }
}
