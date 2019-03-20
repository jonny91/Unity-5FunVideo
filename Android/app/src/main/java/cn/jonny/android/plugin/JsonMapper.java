package cn.jonny.android.plugin;

import com.google.gson.Gson;

public class JsonMapper {
    private static Gson gson;

    public JsonMapper() {
    }

    public static Gson getInstance() {
        if (gson == null) {
            gson = new Gson();
        }

        return gson;
    }
}
