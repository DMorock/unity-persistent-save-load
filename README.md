# unity-persistent-save-load
Simple utility class for persistent data serialization in Unity

Simple utility class for persistent data serialization in Unity using JsonUtility. Supports loading, saving, and deleting JSON files in Application.persistentDataPath by default. Optionally accepts full custom paths.

Load<T> returns default(T) if file doesn't exist or deserialization fails.
Save<T> serializes any serializable class or struct to a JSON file.
⚠️ Uses Unity's JsonUtility — no support for dictionaries, requires [Serializable] on types.

Debug logs and warnings are only active in DEBUG builds.

# todo
Silent failures on save; potential partial writes corrupting data. Return a boolean status indicating success or failure.
Add overloads returning Task using async/await and FileStream. 
Process very large datasets in chunks rather than holding the full JSON string in memory.
Delete removes the specified file without error if it doesn't exist. Check file existance before try to delete.
