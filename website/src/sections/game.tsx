
import {Unity, useUnityContext} from "react-unity-webgl";
//github
// Builds/Games/Build/
// here
// 20Games/Builds/Games/Build/

interface GamePaths{
    path: string;
}
const Game: React.FC<GamePaths> =  ({path}) => {
    const { unityProvider } = useUnityContext({
        loaderUrl: path + "Games.loader.js",
        dataUrl: path + "Games.data.unityweb",
        frameworkUrl: path + "Games.framework.js.unityweb",
        codeUrl: path +"Games.wasm.unityweb",
      });
    
    return (
        <div>
            <Unity unityProvider={unityProvider} />
        </div>
    )
}

export default Game;
