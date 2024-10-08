
import {Unity, useUnityContext} from "react-unity-webgl";
 const Game = () => {
    const { unityProvider } = useUnityContext({
        loaderUrl: "20Games/Builds/Games/Build/Games.loader.js",
        dataUrl: "20Games/Builds/Games/Build/Games.data.unityweb",
        frameworkUrl: "20Games/Builds/Games/Build/Games.framework.js.unityweb",
        codeUrl: "20Games/Builds/Games/Build/Games.wasm.unityweb",
      });
    
    return (
        <div>
            <Unity unityProvider={unityProvider} />
        </div>
    )
}

export default Game;
